using System;
using System.Collections.Generic;
using UnityEngine;

public interface PlayEffect
{
    void OnPlay(Vector2Int value);
}

public interface ModEffect
{
    void OnMod(Vector2Int value);
}

[Serializable]
public struct CardBattleData
{
    public Card preset;

    [Serializable]
    public struct OnPlay
    {
        [SerializeReference, SubclassSelector]
        public PlayEffect type;

        public Vector2Int value;
    }

    [Serializable]
    public struct OnMod
    {
        [SerializeReference, SubclassSelector]
        public ModEffect type;

        public Vector2Int value;
    }

    [Range(0, 6)] public int powerSpace;
    [Range(0, 6)] public int emptyPower;
    [Range(0, 6)] public int normalPower;
    [Range(0, 6)] public int brokenPower;

    [SerializeField] public List<OnPlay> playEffects;
    [SerializeField] public List<OnMod> modEffects;
}