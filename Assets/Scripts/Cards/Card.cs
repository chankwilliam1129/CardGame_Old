using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Card : ScriptableObject
{
    [Header("CardDisplay")]
    public int index;
    public new string name;
    public Sprite image;

    [SpaceAttribute]
    [Range(0, 6)] public int powerSpace;

    [SpaceAttribute]
    [Range(0, 6)] public int emptyPower;

    [Range(0, 6)] public int normalPower;
    [Range(0, 6)] public int brokenPower;


}