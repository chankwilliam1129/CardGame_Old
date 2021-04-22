using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/DealDamage", fileName = "DealDamage")]
public class DealDamage : CardEffect
{
    public DealDamageEvent damageEvent;

    public override string GetDescription(Vector2Int value)
    {
        if (value.y != 0) return value.x.ToString() + "(" + value.y.ToString() + ")ダメージを与える。";
        else return value.x.ToString() + "ダメージを与える。";
    }

    public override void Execute(Vector2Int value, int power)
    {
        DealDamageEvent e = Instantiate(damageEvent, BattleEventManager.Instance.transform);
        e.damage = value.x + value.y * power;
        e.target = EnemyArea.Instance.enemy;
        e.from = PlayerArea.Instance.player;
    }
}