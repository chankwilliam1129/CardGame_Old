using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/AddCondition", fileName = "AddCondition")]
public class AddCondition : CardEffect
{
    public AddConditionEvent addCondition;
    public bool toPlayer;

    public override string GetDescription(Vector2Int value)
    {
        return GetValueString(value) + addCondition.condition.conditionName + "ÅB";
    }

    public override void Execute(Vector2Int value, int power)
    {
        AddConditionEvent e = Instantiate(addCondition, BattleEventManager.Instance.transform);
        e.value = GetFinalValue(value, power);
        if (toPlayer) e.target = PlayerArea.Instance.player;
        else e.target = EnemyArea.Instance.enemy;
    }
}