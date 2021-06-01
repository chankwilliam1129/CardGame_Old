using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy/EnemyAction/EnemyAddCondition", fileName = "EnemyAddCondition")]
public class EnemyAddCondition : EnemyAction
{

    public AddConditionEvent addCondition;
    public Condition condition;

    public bool toPlayer;

    public override string GetDescription(Vector2Int value, int level)
    {
        if(!toPlayer)
            return condition.GetText() + GetValue(value, level) + "ÇìæÇÈÅB";

        else
            return condition.GetText() + GetValue(value, level) + "Çó^Ç¶ÇÈÅB";
    }
    public override void Execute(Vector2Int value, int level)
    {
        AddConditionEvent e = Instantiate(addCondition, BattleEventManager.Instance.transform);
        e.condition = condition;
        e.value = GetValue(value, level);
        if (toPlayer) e.target = PlayerArea.Instance.player;
        else e.target = EnemyArea.Instance.enemy;
    }

}
