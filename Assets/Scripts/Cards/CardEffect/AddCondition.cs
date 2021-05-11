using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/AddCondition", fileName = "AddCondition")]
public class AddCondition : CardEffect
{
    public AddConditionEvent addCondition;
    public Condition condition;

    public bool toPlayer;

    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        if (toPlayer) return condition.GetText() + GetValueString(value, isFinal) + "ÇìæÇÈÅB";
        else return condition.GetText() + GetValueString(value, isFinal) + "Çó^Ç¶ÇÈÅB";
    }

    public override void Execute(Vector2Int value, int power)
    {
        AddConditionEvent e = Instantiate(addCondition, BattleEventManager.Instance.transform);
        e.condition = condition;
        e.value = GetFinalValue(value, power);
        if (toPlayer) e.target = PlayerArea.Instance.player;
        else e.target = EnemyArea.Instance.enemy;
    }
}