using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyAction/EnemyShield", fileName = "EnemyShield")]
public class EnemyShield : EnemyAction
{
    public GetShieldEvent shieldEvent;
    // Start is called before the first frame updat
    public override string GetDescription(Vector2Int value, int level)
    {
        return GetValue(value, level).ToString() + "‚ÌƒV[ƒ‹ƒh‚ğ“¾‚é";
    }

    public override void Execute(Vector2Int value, int level)
    {
        GetShieldEvent e = Instantiate(shieldEvent, BattleEventManager.Instance.transform);
        e.shield = GetValue(value, level);
        e.target = EnemyArea.Instance.enemy;
    }
}
