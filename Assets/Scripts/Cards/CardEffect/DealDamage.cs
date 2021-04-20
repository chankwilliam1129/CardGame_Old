using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/DealDamage", fileName = "DealDamage")]
public class DealDamage : CardEffect
{
    public DealDamageEvent damageEvent;

    public override string GetDescription(Vector2Int value)
    {
        return value.x.ToString() + "É_ÉÅÅ[ÉWÇó^Ç¶ÇÈ";
    }

    public override void Execute(Vector2Int value)
    {
        DealDamageEvent e = Instantiate(damageEvent);
        e.damage = value.x;
        e.target = EnemyArea.Instance.enemy;
        e.from = PlayerArea.Instance.player;
    }
}