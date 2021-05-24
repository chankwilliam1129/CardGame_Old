using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyAction/EnemyShield", fileName = "EnemyShield")]
public class EnemyShield : EnemyAction
{
    public GetShieldEvent shieldEvent;
    // Start is called before the first frame updat
    public override string GetDescription(int value)
    {
        return shieldEvent.ToString() + "‚ÌƒV[ƒ‹ƒh‚ğ“¾‚é";
    }

    public override void Execute(int value)
    {
        GetShieldEvent e = Instantiate(shieldEvent, BattleEventManager.Instance.transform);
        e.shield = value;
        e.target = EnemyArea.Instance.enemy;
    }
}
