using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public List<InventoryItem> Inventory;
    private void Start()
    {
        Inventory = new List<InventoryItem>()
        {
            new InventoryItem(WORLD.item_seed_sunflower, 3)
        };
    }
}
