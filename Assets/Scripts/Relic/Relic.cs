using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Relic : ScriptableObject
{
    [Header("Relic")]
    public new string name;
    public Sprite image;

    [SerializeField, TextArea(1, 3)]
    public string descriptionText;

    [Header("StoreData")]
    public int price;

    public abstract void Generate(RelicDisplay relicDisplay);
}
