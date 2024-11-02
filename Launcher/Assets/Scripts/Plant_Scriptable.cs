using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlantScriptableObject")]
public class Plant_Scriptable : Item_Scriptable
{
    public Seed_Scriptable Seed_Scriptable;
    public int Quantity;
}
