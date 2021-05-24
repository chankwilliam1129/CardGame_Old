using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyAction/EnemyHeal", fileName = "EnemyHeal")]
public class EnemyHeal : EnemyAction
{

    public HealEvent heal;

    public override string GetDescription(int value)
    {
        return heal.ToString() + "‰ñ•œ‚·‚éB";
    }

    public override void Execute(int value)
    {
        HealEvent e = Instantiate(heal, BattleEventManager.Instance.transform);
        e.heal = value;
        e.target = EnemyArea.Instance.enemy;
    }
}
