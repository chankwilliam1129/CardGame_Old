using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Other/BattleSceneData", fileName = "BattleSceneData")]
public class BattleSceneData : ScriptableObject
{
    public List<EnemyData> enemyList;
    public List<Card> cardList;
    public Vector2Int coin;

    public EnemyData GetEnemy()
    {
        return enemyList[Random.Range(0, enemyList.Count)];
    }

    public CardBattleData GetCard()
    {
        return cardList[Random.Range(0, cardList.Count)].battleData;
    }

    public int GetCoin()
    {
        return coin.x + coin.y * MapData.Instance.playerLocation.y;
    }
}
