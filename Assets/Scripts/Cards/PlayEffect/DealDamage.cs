using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealXDamage : CardEffect
{
    public override void OnStart(Vector2Int value, BattleEventManager battle)
    {
        battle.dealDamage += value.x + battle.normalPower * value.y;
    }
}