using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/PenDealDamage", fileName = "PenDealDamage")]
public class PenDealDamage : CardEffect
{
    public PenDealDamageEvent damageEvent;

    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return GetValueString(value, isFinal) + "ダメージを与える。";
    }

    public override void Execute(Vector2Int value, int power)
    {
        PenDealDamageEvent e = Instantiate(damageEvent, BattleEventManager.Instance.transform);
        e.damage = GetFinalValue(value, power);
        e.target = EnemyArea.Instance.enemy;
        e.from = PlayerArea.Instance.player;
    }
}
