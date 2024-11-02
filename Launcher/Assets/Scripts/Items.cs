using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using static Assets.Scripts.WORLD;

public class Items : MonoBehaviour
{

    public List<Seed_Scriptable> SEED_LIST;

    public List<Plant_Scriptable> PLANT_LIST;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Seed_Scriptable GetSeedByID(WORLD.Item_ID item_ID)
    {
        foreach(var item in SEED_LIST)
        {
            if(item_ID == item.ID) return item;
        }
        
        return null;
    }

    public Plant_Scriptable GetPlantByID(WORLD.Item_ID item_ID)
    {
        foreach (var item in PLANT_LIST)
        {
            if (item_ID == item.ID) return item;
        }

        return null;
    }



}
