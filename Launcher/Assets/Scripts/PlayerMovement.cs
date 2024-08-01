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
    public GameObject Panel_Plant_Info;
    public GameObject PanelInventory;
    public GameObject PlantBtn;
    public GameObject PlowBtn;
    public GameObject RemoveBtn;
    
    public float movementSpeed = 5f;
    public LayerMask Plant_Area;

    private float horizontalInput;
    private Vector3 movepoint;
    private bool isMoving = false;

    private Utils _utils;
    private Animator _animator;
    private PlantArea _plantArea;
    private Timer _timer;
    private List<InventoryItem> _inventory;
    void Start()
    {
        _inventory = GameHandler.Inventory;
        _animator = transform.GetComponent<Animator>();
        _utils = new Utils();

        horizontalInput = 1f;
    }

    // Update is called once per frame
    void Update()
    {


        if (isMoving){
            transform.position = Vector3.MoveTowards(transform.position, movepoint, movementSpeed * Time.deltaTime);
            isMoving = false;
            _animator.SetBool("walk", false);
        }

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
                PlowBtn.SetActive(true);
            }
            else
            {
                PlowBtn.SetActive(false);
            }
            
            if(_plantArea.Status == WORLD.PA_PLANTABLE)
            {
                PlantBtn.SetActive(true);
                _animator.SetBool("plow", false);
            }
            else
            {
                PlantBtn.SetActive(false);
            }

            if (_plantArea.Status == WORLD.PA_PLANTED)
            {
                
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
        _animator.SetBool("walk", true);
        isMoving = true;
        movepoint = new Vector3(transform.position.x + position.x, transform.position.y + position.y, transform.position.z);
    }

    public void UpOnClick(){
        Move(new Vector2(0f, 0.5f));
    }   
    public void DownOnClick(){
        Move(new Vector2(0f, -0.5f));
    }   
    public void LeftOnClick(){
        Move(new Vector2(-0.5f, 0f));
        horizontalInput = -1f;
        transform.localScale = new Vector3(-1f,1f,1f);
    }   
    public void RightOnClick(){
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
        Debug.Log("Plant is Click");
        Panel_Plant_Info.SetActive(true);
    }

    public void BtnExitClick()
    {
        Panel_Plant_Info.SetActive(false);
    }

    public void BtnRemoveClick()
    {
        if (_timer != null && _timer.FinishGrowing)
        {
            _inventory.Add(new InventoryItem(_plantArea.PlantPrep.Plant.ItemToGet, _plantArea.PlantPrep.Plant.ItemQuantity));
        }

        PlantAreaReset();
        RemoveBtn.SetActive(false);
        Destroy(_plantArea.PlantObjectReference);
        _plantArea = new PlantArea();
        
    }

    public void PlantAreaReset()
    {
        StartCoroutine(ChangeStatusAfterDelay(0f, WORLD.PA_NEEDS_PREPARATION));
    }

    private IEnumerator ChangeStatusAfterDelay(float delay, int newStatus)
    {
        yield return new WaitForSeconds(delay);
        _plantArea.Status = newStatus;
    }


    public void SowASeed()
    {
        GameObject gameObject = EventSystem.current.currentSelectedGameObject;
        string name = gameObject.name;
        PlantPrep plant = gameObject.GetComponent<PlantPrep>();
        Debug.Log(name);
        switch (name)
        {
            case "Sunflower":
                _plantArea.PlantPrep = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Potato":
                _plantArea.PlantPrep = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Carrot":
                _plantArea.PlantPrep = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Pumpkin":
                _plantArea.PlantPrep = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Beetroot":
                _plantArea.PlantPrep = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Cauliflower":
                _plantArea.PlantPrep = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Parsnip":
                _plantArea.PlantPrep = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Radish":
                _plantArea.PlantPrep = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Wheat":
                _plantArea.PlantPrep = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            default:
                break;
        }

        PlantBtn.SetActive(false);
        BtnExitClick();
    }

    public void BtnInventoryClick()
    {
        PanelInventory.SetActive(true);
    }

    public void BtnInventoryExitClick()
    {
        PanelInventory.SetActive(false);
    }
}
