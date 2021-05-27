using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Other/BattleSceneData", fileName = "BattleSceneData")]
public class BattleSceneData : ScriptableObject
{
    public List<EnemyData> enemyList;
    public List<Card> cardList;
    public int coin;

    public EnemyData GetEnemy()
    {
        return enemyList[Random.Range(0, enemyList.Count)];
    }

    public CardBattleData GetCard()
    {
        return cardList[Random.Range(0, cardList.Count)].battleData;
    }
}
