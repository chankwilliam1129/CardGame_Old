using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyAction/EnemyFireAtk", fileName = "EnemyFireAtk")]

public class EnemyFireAtk : EnemyAction
{
    public DealDamageEvent damage;
   // public AddConditionEvent con;
  

    public override void Execute(int value)
    {
        DealDamageEvent e = Instantiate(damage, BattleEventManager.Instance.transform);
        e.damage = value;
        e.target = PlayerArea.Instance.player;
        e.from = EnemyArea.Instance.enemy;
    }
}
