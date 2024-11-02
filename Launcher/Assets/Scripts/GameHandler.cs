using Assets.Scripts;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameHandler : MonoBehaviour
{
    public InventoryHandler InventoryHandler;
    public event Action InventoryUpdate;
    public TextMeshProUGUI FoodCount;
    public TextMeshProUGUI SeedCount;
    public TextMeshProUGUI GoldCount;


    public List<InventoryItem> Inventory;
    public int Gold = 0;

    private Items WORLD_ITEM;
    private void Start()
    {
        WORLD_ITEM = GetComponent<Items>();
        Inventory = new List<InventoryItem>();
        InventoryHandler.SetInventory(Inventory);
        InventoryUpdate += () => InventoryHandler.UpdateInventory(0);
        
        AddNewItem(new InventoryItem(WORLD_ITEM.GetSeedByID(WORLD.Item_ID.SEED_SUNFLOWER), 3));
        AddNewItem(new InventoryItem(WORLD_ITEM.GetPlantByID(WORLD.Item_ID.SUNFLOWER), 1));

        UpdateFoodCount();
        UpdateGoldCount(1);
        UpdateSeedCount();
    }


    public void AddNewItem(InventoryItem ii)
    {
        foreach (var items in Inventory) { 
            if(items.Details.ID == ii.Details.ID)
            {
                items.Quantity += ii.Quantity;
                InventoryUpdate?.Invoke();
                return;
            }
        }

        Inventory.Add(ii);
        InventoryUpdate?.Invoke();
    }

    public void UseItem(InventoryItem ii)
    {
        foreach (var items in Inventory)
        {
            if (items.Details.ID == ii.Details.ID)
            {
                items.Quantity -= 1;
                
                if(items.Quantity == 0)
                {
                    Inventory.Remove(ii);
                }
                InventoryUpdate?.Invoke();
                return;
            }
        }
    }

    public void UpdateFoodCount()
    {
        int total = 0;
        foreach (var item in Inventory) { 
            if(item.Details.Type == WORLD.Item_TYPE.PLANT && item.Details.ID != WORLD.Item_ID.SUNFLOWER)
            {
                total += item.Quantity;
            }
        }

        FoodCount.text = total.ToString();
    }

    public void UpdateSeedCount()
    {
        int total = 0;
        foreach (var item in Inventory)
        {
            if (item.Details.Type == WORLD.Item_TYPE.SEED)
            {
                total += item.Quantity;
            }
        }

        SeedCount.text = total.ToString();
    }

    public void UpdateGoldCount(int n)
    {
        Gold += n;
        GoldCount.text = Gold.ToString();
    }
}
