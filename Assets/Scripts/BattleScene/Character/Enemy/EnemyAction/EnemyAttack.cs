using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyAction/EnemyAttack", fileName = "EnemyAttack")]
public class EnemyAttack : EnemyAction
{
    public DealDamageEvent damage;

    public override string GetDescription(Vector2Int value, int level)
    {
        return GetValue(value, level).ToString() + "ダメージ与える。";
    }

    public override void Execute(Vector2Int value, int level)
    {
        DealDamageEvent e = Instantiate(damage, BattleEventManager.Instance.transform);
        e.damage = GetValue(value, level);
        e.target = PlayerArea.Instance.player;
        e.from = EnemyArea.Instance.enemy;
    }
}