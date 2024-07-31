using UnityEngine;
using UnityEngine.Diagnostics;
using Assets.Scripts;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Panel_Plant_Info;
    public GameObject PlantBtn;
    public GameObject PlowBtn;
    public GameObject RemoveBtn;
    public float movementSpeed = 5f;
    public LayerMask Plant_Area;

    private float horizontalInput;
    private Vector3 movepoint;
    private bool isMoving = false;

    private Utils utils;
    private Animator animator;
    private PlantArea plantArea;
    void Start()
    {
        horizontalInput = 1f;
        animator = transform.GetComponent<Animator>();
        utils = new Utils();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            transform.position = Vector3.MoveTowards(transform.position, movepoint, movementSpeed * Time.deltaTime);
            isMoving = false;
            animator.SetBool("walk", false);
        }

        if (utils.createBoxCast(transform, new Vector2(0.5f, 0.1f), 0.09f * horizontalInput, 0.06f, Plant_Area))
        {
            Testing testing = utils.ObjectReference.GetComponent<Testing>();
            
            plantArea = testing.plantArea;

            if(plantArea.Status == WORLD.PA_NEEDS_PREPARATION)
            {
                PlowBtn.SetActive(true);
            }
            else
            {
                PlowBtn.SetActive(false);
            }
            
            if(plantArea.Status == WORLD.PA_PLANTABLE)
            {
                PlantBtn.SetActive(true);
                animator.SetBool("plow", false);
            }
            else
            {
                PlantBtn.SetActive(false);
            }

            if (plantArea.Status == WORLD.PA_PLANTED)
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
        animator.SetBool("walk", true);
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
        animator.SetBool("plow", true);
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
        RemoveBtn.SetActive(false);
        Destroy(plantArea.PlantObjectReference);
        plantArea = new PlantArea();
        PlantAreaReset();
    }

    public void PlantAreaReset()
    {
        StartCoroutine(ChangeStatusAfterDelay(0f, WORLD.PA_NEEDS_PREPARATION));
    }

    private IEnumerator ChangeStatusAfterDelay(float delay, int newStatus)
    {
        yield return new WaitForSeconds(delay);
        plantArea.Status = newStatus;
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
                plantArea.Plant = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Potato":
                plantArea.Plant = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Carrot":
                plantArea.Plant = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Pumpkin":
                plantArea.Plant = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Beetroot":
                plantArea.Plant = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Cauliflower":
                plantArea.Plant = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Parsnip":
                plantArea.Plant = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Radish":
                plantArea.Plant = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            case "Wheat":
                plantArea.Plant = plant;
                StartCoroutine(ChangeStatusAfterDelay(1f, WORLD.PA_PLANTED));
                break;
            default:
                break;
        }

        PlantBtn.SetActive(false);
        BtnExitClick();
    }


}
