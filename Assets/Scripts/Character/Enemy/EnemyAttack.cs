using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAction/EnemyAttack", fileName = "EnemyAttack")]
public class EnemyAttack : EnemyAction
{

    public DealDamageEvent damage;


    public override void Execute(int value)
    {
        DealDamageEvent e = Instantiate(damage);
        e.damage = value;
        e.target = PlayerArea.Instance.player;
        e.from = EnemyArea.Instance.enemy;
    }


}