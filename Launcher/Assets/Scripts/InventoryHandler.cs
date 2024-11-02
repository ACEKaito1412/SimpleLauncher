using Assets.Scripts;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
    public PlayerMovement Player;
    public GameHandler GameHandler;
    public GameObject UI_Item_Base;

    public GameObject Item_Description_Container;
    public TextMeshProUGUI Item_Name_TMPRO;
    public TextMeshProUGUI Item_Description_TMPRO;
    public Image Item_Image;

    public GameObject PanelPlant;
    public GameObject PanelSell;
    public GameObject PanelExtract;

    public Image TabItem;
    public Image TabSeeds;
    public Image TabTools;

    private Utils utils = new Utils();
    private List<InventoryItem> _inventory;
    private InventoryItem _selectedItem;
    private Items WORLD_ITEM;
    void Start()
    {
        WORLD_ITEM = GameHandler.GetComponent<Items>();
    }

    public void SetInventory(List<InventoryItem> inventory)
    {
        _inventory = inventory;
    }


    public void UpdateInventory(int type)
    {
        foreach (Transform child in transform)
        {
            if (child != UI_Item_Base.transform)
            {
                Destroy(child.gameObject);
            }
        }

        
        foreach (var item in _inventory)
        {

            switch (type)
            {
                case 0:
                    SetUpItem(item);
                    break;
                case 1:
                    if(item.Details.Type == WORLD.Item_TYPE.SEED)
                    {
                        SetUpItem(item);
                    }
                    break;
                case 2:
                    if (item.Details.Type == WORLD.Item_TYPE.TOOL)
                    {
                        SetUpItem(item);
                    }
                    break;
            }
        }

        
    }

    public void SetUpItem(InventoryItem ii) {
        GameObject gameItem = Instantiate(UI_Item_Base);
        gameItem.transform.SetParent(transform, false);
        gameItem.SetActive(true);

        //Change the text mesh pro;

        TextMeshProUGUI itemName = gameItem.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        Image itemImage = gameItem.transform.GetChild(1).GetComponent<Image>();
        Button itemBtn = gameItem.GetComponent<Button>();

        if (itemName != null)
        {
            itemName.text = ii.Quantity.ToString();
        }

        if (itemImage != null)
        {
            itemImage.sprite = ii.Details.Icon;
        }

        if (itemBtn != null)
        {
            itemBtn.onClick.AddListener(() => { OnClickItem(ii.Details.ID); });
        }
    }

    public void GetFirstItem()
    {
        InventoryItem ii = _inventory[0];
        _selectedItem = ii;
        UpdateDescription(ii);
    }

    public InventoryItem GetItemData(WORLD.Item_ID searchId)
    {
        foreach (var item in _inventory) { 
            if(item.Details.ID == searchId)
            {
                return item;
            }
        }

        return null;
    }

    public void OnClickItem(WORLD.Item_ID itemID)
    {
        Item_Description_Container.SetActive(true);
        InventoryItem item = GetItemData(itemID);
        _selectedItem = item;
        UpdateDescription(item);
    }

    public void UpdateDescription(InventoryItem ii)
    {
        Item_Name_TMPRO.text = ii.Details.Name;
        Item_Description_TMPRO.text = ii.Details.Description;
        Item_Image.sprite = ii.Details.Icon;

        if(ii.Details.Type == WORLD.Item_TYPE.PLANT)
        {
            PanelExtract.SetActive(true);
            PanelSell.SetActive(true);
            PanelPlant.SetActive(false);
        }

        if (ii.Details.Type == WORLD.Item_TYPE.SEED && Player._inPlantArea)
        {
            PanelExtract.SetActive(false);
            PanelSell.SetActive(true);
            PanelPlant.SetActive(true);
        }else if(ii.Details.Type == WORLD.Item_TYPE.SEED && !Player._inPlantArea)
        {
            PanelExtract.SetActive(false);
            PanelSell.SetActive(true);
            PanelPlant.SetActive(false);
        }
    }

    public void BtnPlantClick()
    {
        utils.SetImageOpacity(TabSeeds, 1f);
        utils.SetImageOpacity(TabTools, 0.5f);
        utils.SetImageOpacity(TabItem, 0.5f);
        UpdateInventory(1);
    }

    public void BtnItemClick()
    {
        utils.SetImageOpacity(TabSeeds, 0.5f);
        utils.SetImageOpacity(TabItem, 1f);
        utils.SetImageOpacity(TabTools, 0.5f);
        UpdateInventory(0);
    }

    public void BtnToolClick()
    {
        utils.SetImageOpacity(TabSeeds, 0.5f);
        utils.SetImageOpacity(TabItem, 0.5f);
        utils.SetImageOpacity(TabTools, 1f);
        UpdateInventory(2);
    }

    public void OnClickPlant()
    {
        Player.SowASeed(_selectedItem);
    }

    public void OnClickExtract()
    {
        if (_selectedItem.Details.Type == WORLD.Item_TYPE.PLANT) {
            Plant_Scriptable plant_Scriptable = WORLD_ITEM.GetPlantByID(_selectedItem.Details.ID);
            InventoryItem newItem = new InventoryItem(plant_Scriptable.Seed_Scriptable, plant_Scriptable.Quantity);

            GameHandler.UseItem(_selectedItem);
            GameHandler.AddNewItem(newItem);
        }
    }

    public void OnClickSell()
    {
        if (CheckItemCount(_selectedItem) != 0)
        {
            GameHandler.UseItem(_selectedItem);
            GameHandler.UpdateGoldCount(_selectedItem.Details.Sell_Price);
        }

        if(CheckItemCount(_selectedItem) == 0)
        {
            Item_Description_Container.SetActive(false);
        }
    }

    public int CheckItemCount(InventoryItem searchItem)
    {
        foreach(InventoryItem item in _inventory)
        {
            if(item.Details == searchItem.Details)
            {
                return item.Quantity;
            }
        }

        return 0;
    }
}
