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


    [Serializable]
    public class EnemyActionData
    {
        public EnemyAction type;
        public int value;
    }

    public bool isActionRandom;

    [SerializeField] public List<EnemyActionData> EnemyNormalActions1;
    [SerializeField] public List<EnemyActionData> EnemyNormalActions2;
    [SerializeField] public List<EnemyActionData> EnemyNormalActions3;

    [SerializeField] public List<EnemyActionData> EnemySpecialActions1;
    [SerializeField] public List<EnemyActionData> EnemySpecialActions2;
    [SerializeField] public List<EnemyActionData> EnemySpecialActions3;
}