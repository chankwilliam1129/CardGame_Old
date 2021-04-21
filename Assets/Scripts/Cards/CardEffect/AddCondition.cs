using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/AddCondition", fileName = "AddCondition")]
public class AddCondition : CardEffect
{
    public AddConditionEvent addCondition;

    public override string GetDescription(Vector2Int value)
    {
        return value.x.ToString() + addCondition.condition.conditionName;
    }

    public override void Execute(Vector2Int value)
    {
        AddConditionEvent e = Instantiate(addCondition);
        e.value = value.x;
        e.target = EnemyArea.Instance.enemy;
    }
}