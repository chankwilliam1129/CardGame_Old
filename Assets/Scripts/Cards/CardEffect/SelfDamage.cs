using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/SelfDamage", fileName = "SelfDamage")]

public class SelfDamage : CardEffect
{

    public SelfDamageEvent damageEvent;


    public override string GetDescription(Vector2Int value)
    {
        return "(" + value.x.ToString() + ")ƒ_ƒ[ƒW‚ğ©•ª‚É—^‚¦‚é";
    }

    public override void Execute(Vector2Int value)
    {
        SelfDamageEvent e = Instantiate(damageEvent);
        e.damage = value.x;
        e.target = PlayerArea.Instance.player;
    }



}
