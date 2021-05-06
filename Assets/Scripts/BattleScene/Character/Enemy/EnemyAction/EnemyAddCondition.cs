using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy/EnemyAction/EnemyAddCondition", fileName = "EnemyAddCondition")]
public class EnemyAddCondition : EnemyAction
{

    public AddConditionEvent addCondition;

    public bool toPlayer;

    public override void Execute(int value)
    {
        AddConditionEvent e = Instantiate(addCondition, BattleEventManager.Instance.transform);
        e.value = value;
        if (toPlayer) e.target = PlayerArea.Instance.player;
        else e.target = EnemyArea.Instance.enemy;
    }

}