using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/SelfDamage", fileName = "SelfDamage")]
public class SelfDamage : CardEffect
{
    public SelfDamageEvent damageEvent;

    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return "ëÃóÕÇ" + GetValueString(value, isFinal) + "é∏Ç§ÅB";
    }

    public override void Execute(Vector2Int value, int power)
    {
        SelfDamageEvent e = Instantiate(damageEvent, BattleEventManager.Instance.transform);
        e.damage = GetFinalValue(value, power);
        e.target = PlayerArea.Instance.player;
    }
}