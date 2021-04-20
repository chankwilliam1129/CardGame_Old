using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardData", fileName = "CardData")]
public class Card : ScriptableObject
{
    public int index;

    [Header("CardDisplay")]
    public new string name;

    public Sprite image;

    [Header("CardData")]
    public CardBattleData battleData;
}