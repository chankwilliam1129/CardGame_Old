using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/DealDamage", fileName = "DealDamage")]
public class DealDamage : CardEffect
{
    public DealDamageEvent damageEvent;

    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return GetValueString(value, isFinal) + "ダメージを与える。";
    }

    public override void Execute(Vector2Int value, int power)
    {
        DealDamageEvent e = Instantiate(damageEvent, BattleEventManager.Instance.transform);
        e.damage = GetFinalValue(value, power);
        e.target = EnemyArea.Instance.enemy;
        e.from = PlayerArea.Instance.player;
    }
}