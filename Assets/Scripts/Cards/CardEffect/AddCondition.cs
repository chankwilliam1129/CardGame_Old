using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/AddCondition", fileName = "AddCondition")]
public class AddCondition : CardEffect
{
    public AddConditionEvent addCondition;

    public override string GetDescription(Vector2Int value)
    {
        if (value.y != 0) return value.x.ToString() + "(" + value.y.ToString() + ")" + addCondition.condition.conditionName + "ÅB";
        return value.x.ToString() + addCondition.condition.conditionName + "ÅB";
    }

    public override void Execute(Vector2Int value, int power)
    {
        AddConditionEvent e = Instantiate(addCondition);
        e.value = value.x + value.y * power;
        e.target = EnemyArea.Instance.enemy;
    }
}