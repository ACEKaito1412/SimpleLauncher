using UnityEngine;
using UnityEngine.Diagnostics;
using Assets.Scripts;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public GameHandler GameHandler;
    public GameObject PanelInventory;
    public GameObject PanelAppMenu;
    public GameObject PlantBtn;
    public GameObject PlowBtn;
    public GameObject RemoveBtn;

    public float movementSpeed = 5f;
    public LayerMask Plant_Area;
    public bool _inPlantArea;

    private float horizontalInput;
    private Vector3 movepoint;
    private bool isMoving = false;

    private Utils _utils;
    private Animator _animator;
    private Timer _timer;
    private PlantArea _plantArea;
    private Items WORLD_ITEM;
    void Start()
    {
        WORLD_ITEM = GameHandler.GetComponent<Items>();
        _inPlantArea = false;
        _animator = GetComponent<Animator>();
        _utils = new Utils();

        horizontalInput = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving){
            transform.position = Vector3.MoveTowards(transform.position, movepoint, movementSpeed * Time.deltaTime);
            isMoving = false;
            _animator.SetBool("plow", false);
        }
        else
        {
            _animator.SetBool("walk_forward", false);
            _animator.SetBool("walk_t", false);
            _animator.SetBool("walk_d", false);
            
        }

        SetupPlantArea();
    }

    public void SetupPlantArea()
    {
        if (_utils.createBoxCast(transform, new Vector2(0.5f, 0.1f), 0.09f * horizontalInput, 0.06f, Plant_Area))
        {
            SoilHandler soilHandler = _utils.ObjectReference.GetComponent<SoilHandler>();

            _plantArea = soilHandler.plantArea;

            if (_plantArea.PlantObjectReference != null)
            {
                _timer = _plantArea.PlantObjectReference.GetComponent<Timer>();
            }

            if (_plantArea.Status == WORLD.PA_NEEDS_PREPARATION)
            {
                _inPlantArea = false;
                PlowBtn.SetActive(true);
            }
            else
            {
                PlowBtn.SetActive(false);
            }

            if (_plantArea.Status == WORLD.PA_PLANTABLE)
            {
                _inPlantArea = true;
                PlantBtn.SetActive(true);
                _animator.SetBool("plow", false);
            }
            else
            {
                PlantBtn.SetActive(false);
            }

            if (_plantArea.Status == WORLD.PA_PLANTED)
            {
                _inPlantArea = false;
                RemoveBtn.SetActive(true);
            }
            else
            {
                RemoveBtn.SetActive(false);
            }
            

        }
        else
        {
            PlantBtn.SetActive(false);
            PlowBtn.SetActive(false);
            RemoveBtn.SetActive(false);
        }
    }

    private void Move(Vector2 position){
        isMoving = true;
        movepoint = new Vector3(transform.position.x + position.x, transform.position.y + position.y, transform.position.z);
        //transform.position =  new Vector3(transform.position.x + (movementSpeed * position.x), transform.position.y + (movementSpeed * position.y), transform.position.z);    
    }


    #region BTNS
    public void UpOnClick(){
        _animator.SetBool("walk_t", true);
        Move(new Vector2(0f, 0.5f));
    }   
    public void DownOnClick(){
        _animator.SetBool("walk_forward", true);
        Move(new Vector2(0f, -0.5f));
    }   
    public void LeftOnClick(){
        _animator.SetBool("walk_forward", true);
        Move(new Vector2(-0.5f, 0f));
        horizontalInput = -1f;
        transform.localScale = new Vector3(-1f,1f,1f);
    }   
    public void RightOnClick(){
        _animator.SetBool("walk_forward", true);
        Move(new Vector2(0.5f, 0f));
        horizontalInput = 1f;
        transform.localScale = new Vector3(1f,1f,1f);
    }

    public void BtnPlowClick()
    {
        _animator.SetBool("plow", true);
        StartCoroutine(ChangeStatusAfterDelay(3f, WORLD.PA_PLANTABLE)); 
        PlowBtn.SetActive(false);
    }

    public void BtnPlantClick()
    {
        PanelInventory.SetActive(true);
    }

    public void BtnExitClick()
    {
        PanelInventory.SetActive(false);
    }

    public void BtnRemoveClick()
    {
        if (_timer != null && _timer.FinishGrowing)
        {
            GameHandler.AddNewItem(new InventoryItem(_plantArea.SeedDetails.Plant_Scriptable, _plantArea.SeedDetails.Quantity));
        }

        PlantAreaReset();
        RemoveBtn.SetActive(false);
        Destroy(_plantArea.PlantObjectReference);
        _plantArea = new PlantArea();
        
    }

    public void BtnInventoryClick()
    {
        PanelInventory.SetActive(true);
    }

    public void BtnInventoryExitClick()
    {
        PanelInventory.SetActive(false);
    }

    public void BtnAppMenuClick()
    {
        PanelAppMenu.SetActive(true);
    }

    public void BtnAppMenuExit()
    {
        PanelAppMenu.SetActive(false);
    }

    #endregion
    public void PlantAreaReset()
    {
        StartCoroutine(ChangeStatusAfterDelay(0f, WORLD.PA_NEEDS_PREPARATION));
    }

    private IEnumerator ChangeStatusAfterDelay(float delay, int newStatus)
    {
        yield return new WaitForSeconds(delay);
        _plantArea.Status = newStatus;
    }
    
    public void SowASeed(InventoryItem selectedItem)
    {
        Seed_Scriptable plant = WORLD_ITEM.GetSeedByID(selectedItem.Details.ID);
        Debug.Log($"{name} {plant.Sprites.Length}");

        _plantArea.SeedDetails = plant;
        GameHandler.UseItem(selectedItem);
        StartCoroutine(ChangeStatusAfterDelay(0f, WORLD.PA_PLANTED));

        PlantBtn.SetActive(false);
        BtnExitClick();
    }
}