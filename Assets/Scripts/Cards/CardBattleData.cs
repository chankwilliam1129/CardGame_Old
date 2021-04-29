using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct CardBattleData
{
    [HideInInspector]
    public Card preset;

    [Serializable]
    public class Effect
    {
        public CardEffect type;
        public Vector2Int value;
    }

    [Range(0, 10)] public int powerSpace;
    [Range(0, 6)] public int emptyPower;
    [Range(0, 6)] public int normalPower;
    [Range(0, 6)] public int brokenPower;

    public BattleDeckManager.RemoveType removeType;

    [SerializeField] public List<Effect> playEffects;
    [SerializeField] public List<Effect> modEffects;
}