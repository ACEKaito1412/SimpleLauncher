using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemScriptableObject")]
public class Item_Scriptable : ScriptableObject
{
    public WORLD.Item_ID ID;
    public string Name;
    public WORLD.Item_TYPE Type;
    public string Description;
    public Sprite Icon;
    public int Sell_Price;
    public int Buy_Price;
}
