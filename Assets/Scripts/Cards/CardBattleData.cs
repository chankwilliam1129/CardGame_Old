using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct CardBattleData
{
    [HideInInspector] public Card preset;

    [Serializable]
    public class Effect
    {
        public CardEffect type;
        public Vector2Int value;
    }

    [Range(0, 10)] public int powerSpace;
    [Range(0, 10)] public int emptyPower;
    [Range(0, 6)] public int normalPower;
    [Range(0, 6)] public int brokenPower;

    [HideInInspector] public BattleDeckManager.RemoveType removeType;

    [HideInInspector] public BattleDeckManager.DrawType drawType;

    [SerializeField] public List<Effect> effects;
}