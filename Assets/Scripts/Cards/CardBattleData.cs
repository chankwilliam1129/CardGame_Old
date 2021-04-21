using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct CardBattleData
{
    public Card preset;
    public bool enemySelect;

    [Serializable]
    public class Effect
    {
        public CardEffect type;
        public Vector2Int value;
    }

    [Range(0, 6)] public int powerSpace;
    [Range(0, 6)] public int emptyPower;
    [Range(0, 6)] public int normalPower;
    [Range(0, 6)] public int brokenPower;

    [SerializeField] public List<Effect> playEffects;
    [SerializeField] public List<Effect> modEffects;
}