using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/HealHP", fileName = "HealHp")]
public class HealHp : CardEffect
{
    public HealHpEvent healHpEvent;

    public override string GetDescription(Vector2Int value)
    {
        return value.x.ToString() + "É_ÉÅÅ[ÉWÇó^Ç¶ÇÈ";
    }

    public override void Execute(Vector2Int value)
    {
        HealHpEvent e = Instantiate(healHpEvent);
        e.heal = value.x;
        e.target = PlayerArea.Instance.player;
    }
}
