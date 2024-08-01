using Assets.Scripts;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class InventoryHandler : MonoBehaviour
{
    public GameObject UI_Item_Base;
    public GameHandler GameHandler;
    private List<InventoryItem> _inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inventory = GameHandler.Inventory;

        foreach (var item in _inventory)
        {
            GameObject gameItem = Instantiate(UI_Item_Base);
            gameItem.transform.SetParent(transform, false);
            gameItem.SetActive(true);

            //Change the text mesh pro;

            TextMeshProUGUI itemName = gameItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            if(itemName != null)
            {
                itemName.text = item.Details.Name + " X " + item.Quantity;
            }
            
        }
    }
    
}
