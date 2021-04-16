using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CardEffect/DealDamage", fileName = "DealDamage")]
public class DealDamage : CardEffect
{

    public override string GetDescription(Vector2Int value)
    {
        return value.x.ToString() + "ƒ_ƒ[ƒW‚ğ—^‚¦‚é";
    }
}