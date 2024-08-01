using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.EventSystems;
using System;
using Unity.VisualScripting;
using TMPro;
public class SoilHandler : MonoBehaviour
{
    public Sprite sprite_needs_preparation;
    public Sprite sprite_plowed;
    public Sprite sprite_planted;
    public GameObject plant_base;
    public PlantArea plantArea;
    private SpriteRenderer spriteRenderer;
    private int previousStatus;
    private int currentSprite = 1;

    public void Start()
    {
        plantArea = new PlantArea();
        spriteRenderer = GetComponent<SpriteRenderer>();
        previousStatus = plantArea.Status; // Initialize with the current status
        UpdateSprite(); // Set the initial sprite based on the status
    }

    public void Update()
    {
        // Only update the sprite if the status has changed
        if (plantArea.Status != previousStatus)
        {
            previousStatus = plantArea.Status; // Update the previous status
            UpdateSprite(); // Change the sprite based on the new status

            if(plantArea.Status == WORLD.PA_PLANTED && plantArea.PlantObjectReference == null)
            {
                GameObject newPlantObject = Instantiate(plant_base, new Vector3(0,0.098f), Quaternion.identity);
                newPlantObject.transform.SetParent(transform, false);

                SpriteRenderer plantSpriteRenderer = newPlantObject.GetComponent<SpriteRenderer>();
                PlantPrep plantPrep = plantArea.PlantPrep;
                plantSpriteRenderer.sprite = plantPrep.seed_0;
                plantArea.PlantObjectReference = newPlantObject;

                TextMeshPro textComponent = newPlantObject.transform.GetChild(0).GetComponent<TextMeshPro>();

                Timer timer = newPlantObject.GetComponent<Timer>();
                timer.text = textComponent;
                timer.Initialize(plantPrep.Plant.TimeToRipe);
                timer.TimerEnded += () => PlantIsRiped(plantSpriteRenderer);
                timer.Grow += () => PlantGrow(plantSpriteRenderer);
                timer.StartTimer();
                currentSprite = 1;
            }
        }
    }

    private void UpdateSprite()
    {
        if(plantArea.Status == WORLD.PA_NEEDS_PREPARATION)
        {
            spriteRenderer.sprite = sprite_needs_preparation;
            return;
        }

        if (plantArea.Status == WORLD.PA_PLANTABLE) {
            spriteRenderer.sprite = sprite_plowed;
            return; 
        }

        if (plantArea.Status == WORLD.PA_PLANTED) {
            spriteRenderer.sprite = sprite_planted;
            return;
        }
    }

    private void PlantGrow(SpriteRenderer spriteRenderer)
    {

        switch (currentSprite) {
            case 1:
                spriteRenderer.sprite = plantArea.PlantPrep.seed_1;
                break;
            case 2:
                spriteRenderer.sprite = plantArea.PlantPrep.seed_2;
                break;
            case 3:
                spriteRenderer.sprite = plantArea.PlantPrep.seed_3;
                break;
            default:
                break;
        }
        currentSprite++;
    }

    private void PlantIsRiped(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.sprite = plantArea.PlantPrep.seed_4;
    }

}

