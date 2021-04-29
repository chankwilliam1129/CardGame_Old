using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy/EnemyAction/EnemyAddCondition", fileName = "EnemyAddCondition")]
public class EnemyAddCondition : EnemyAction
{

    public AddConditionEvent addCondition;

    public override void Execute(int value)
    {
        AddConditionEvent e = Instantiate(addCondition, BattleEventManager.Instance.transform);
        e.value = value;
        e.target = PlayerArea.Instance.player;
    }

}
