using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemScriptableObject")]
public class Seed_Scriptable : Item_Scriptable
{
    public GrowthSpr[] Sprites;

    [System.Serializable]
    public struct GrowthSpr
    {
        public Sprite spr_0, spr_1, spr_2, spr_3, spr_4, spr_5;
    }
    public int Duration;
    public Plant_Scriptable Plant_Scriptable;
    public int Quantity;
}
