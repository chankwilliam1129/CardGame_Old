using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyAction/EnemyAttack", fileName = "EnemyAttack")]
public class EnemyAttack : EnemyAction
{
    public DealDamageEvent damage;

    public override string GetDescription(int value)
    {
        return damage.ToString() + "ダメージ与える。";
    }

    public override void Execute(int value)
    {
        DealDamageEvent e = Instantiate(damage, BattleEventManager.Instance.transform);
        e.damage = value;
        e.target = PlayerArea.Instance.player;
        e.from = EnemyArea.Instance.enemy;
    }
}