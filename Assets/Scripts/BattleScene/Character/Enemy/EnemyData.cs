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

    public Vector2Int health;


    [Serializable]
    public class EnemyActionData
    {
        public EnemyAction type;
        public Vector2Int value;
    }

    public bool isActionRandom;

    [SerializeField] public List<EnemyActionData> EnemyNormalActions1;
    [SerializeField] public List<EnemyActionData> EnemyNormalActions2;
    [SerializeField] public List<EnemyActionData> EnemyNormalActions3;
    [SerializeField] public List<EnemyActionData> EnemyNormalActions4;
    [SerializeField] public List<EnemyActionData> EnemyNormalActions5;

    [SerializeField] public List<EnemyActionData> EnemySpecialActions1;
    [SerializeField] public List<EnemyActionData> EnemySpecialActions2;
    [SerializeField] public List<EnemyActionData> EnemySpecialActions3;
    [SerializeField] public List<EnemyActionData> EnemySpecialActions4;
    [SerializeField] public List<EnemyActionData> EnemySpecialActions5;

    public int GetHealth(int level)
    {
        return health.x + health.y * level;
    }
}