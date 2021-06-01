using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyAction/EnemyPenAttack", fileName = "EnemyPenAttack")]

public class EnemyPenAttack : EnemyAction
{
    public PenDealDamageEvent damage;

    public override string GetDescription(Vector2Int value, int level)
    {
        return GetValue(value, level).ToString() + "の貫通ダメージ与える。";
    }

    public override void Execute(Vector2Int value, int level)
    {
        PenDealDamageEvent e = Instantiate(damage, BattleEventManager.Instance.transform);
        e.damage = GetValue(value, level);
        e.target = PlayerArea.Instance.player;
        e.from = EnemyArea.Instance.enemy;
    }
}
