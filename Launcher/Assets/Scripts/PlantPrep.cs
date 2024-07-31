using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts;


public class PlantPrep : MonoBehaviour
{
    public string PlantName;

    public Sprite seed_0;
    public Sprite seed_1;
    public Sprite seed_2;
    public Sprite seed_3;
    public Sprite seed_4;
    public Sprite seed_5;

    public Plant Plant { get; set; }

    public void Start()
    {
        switch (PlantName)
        {
            case "Sunflower":
                Plant = WORLD.Seed_SunFlower;
                break;
            case "Potato":
                Plant = WORLD.Seed_Potato;
                break;
            case "Carrot":
                Plant = WORLD.Seed_Carrot;
                break;
            case "Pumpkin":
                Plant = WORLD.Seed_Pumpkin;
                break;
            case "Beetroot":
                Plant = WORLD.Seed_Beetroot;
                break;
            case "Cauliflower":
                Plant = WORLD.Seed_Cauliflower;
                break;
            case "Parsnip":
                Plant = WORLD.Seed_Parsnip;
                break;
            case "Radish":
                Plant = WORLD.Seed_Radish;
                break;
            case "Wheat":
                Plant = WORLD.Seed_Wheat;
                break;
            default:
                break;
        }
    }

}

