using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyAction/EnemyHeal", fileName = "EnemyHeal")]
public class EnemyHeal : EnemyAction
{

    public HealEvent heal;

    public override string GetDescription(Vector2Int value, int level)
    {
        return GetValue(value, level).ToString() + "‰ñ•œ‚·‚éB";
    }

    public override void Execute(Vector2Int value, int level)
    {
        HealEvent e = Instantiate(heal, BattleEventManager.Instance.transform);
        e.heal = GetValue(value, level);
        e.target = EnemyArea.Instance.enemy;
    }
}
