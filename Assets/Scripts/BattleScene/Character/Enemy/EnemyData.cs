using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyData", fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    //[Header("CardDisplay")]
    public new string name;

    public Sprite image;

    public int health;

    public int Atk_Ntimes;

    [Serializable]
    public class EnemyActionData
    {
        public EnemyAction type;
        public int value;
    }

    [SerializeField] public List<EnemyActionData> EnemyActions;
}