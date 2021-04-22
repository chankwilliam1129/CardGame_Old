using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/DealDamage", fileName = "DealDamage")]
public class DealDamage : CardEffect
{
    public DealDamageEvent damageEvent;

    public override string GetDescription(Vector2Int value)
    {
        return "(" + value.x.ToString() + ")ダメージを与える。";
    }

    public override void Execute(Vector2Int value)
    {
        DealDamageEvent e = Instantiate(damageEvent);
        e.damage = value.x;
        e.target = EnemyArea.Instance.enemy;
        e.from = PlayerArea.Instance.player;
    }
}