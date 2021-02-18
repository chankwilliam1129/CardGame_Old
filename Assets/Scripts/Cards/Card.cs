using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Card : ScriptableObject
{
    [Serializable] public struct PlayEffect
    {
        public enum Type
        {
            Deal_A_Damage,
            DealDamage_A_Time,
            Draw_A_Card,
        }

        public Type type;
        public Vector2Int valueA;
    }

    [Serializable] public struct ModEffect
    {
        public enum Type
        {
            Extra_X_Damage_Y_Time,
        }

        public Type type;
        public int valueX;
        public int valueY;
    }

    [Header("CardDisplay")]
    public int index;
    public new string name;
    public Sprite image;

    [Space]
    [Range(0, 6)] public int powerSpace;

    [Space]
    [Range(0, 6)] public int emptyPower;

    [Range(0, 6)] public int normalPower;
    [Range(0, 6)] public int brokenPower;

    [Space]
    [SerializeField] public List<PlayEffect> playEffects;
}