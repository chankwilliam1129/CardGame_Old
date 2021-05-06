using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyAction/EnemyPenAttack", fileName = "EnemyPenAttack")]

public class EnemyPenAttack : EnemyAction
{
    public PenDealDamageEvent damage;

    public override void Execute(int value)
    {
        PenDealDamageEvent e = Instantiate(damage, BattleEventManager.Instance.transform);
        e.damage = value;
        e.target = PlayerArea.Instance.player;
        e.from = EnemyArea.Instance.enemy;
    }
}
