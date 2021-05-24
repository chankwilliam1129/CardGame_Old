using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy/EnemyAction/EnemyAddCondition", fileName = "EnemyAddCondition")]
public class EnemyAddCondition : EnemyAction
{

    public AddConditionEvent addCondition;
    public Condition condition;

    public bool toPlayer;

    public override string GetDescription(int value)
    {
        return condition.GetText() + value + "Çó^Ç¶ÇÈÅB";
    }
    public override void Execute(int value)
    {
        AddConditionEvent e = Instantiate(addCondition, BattleEventManager.Instance.transform);
        e.condition = condition;
        e.value = value;
        if (toPlayer) e.target = PlayerArea.Instance.player;
        else e.target = EnemyArea.Instance.enemy;
    }

}
