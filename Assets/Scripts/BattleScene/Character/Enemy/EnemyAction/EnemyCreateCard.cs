using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyAction/EnemyCreateCard", fileName = "EnemyCreateCard")]

public class EnemyCreateCard : EnemyAction
{
    public CreateCardEvent createCardEvent;
    public Card card;

    public override string GetDescription(Vector2Int value, int level)
    {
        return card.name + "を" + GetValue(value, level) + "枚プレイヤーの手札に加える。";
    }

    public override void Execute(Vector2Int value, int level)
    {
        int draw = GetValue(value, level);
        for (int i = 0; i < draw; i++)
        {
            Instantiate(createCardEvent, BattleEventManager.Instance.transform).card.data = card.battleData;
        }
    }
}