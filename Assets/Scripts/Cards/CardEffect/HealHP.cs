using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/HealHp", fileName = "HealHp")]

public class HealHP : CardEffect
{

    public HealHpEvent healEvent;

    // Start is called before the first frame update
    public override string GetDescription(Vector2Int value)
    {
        return value.x.ToString() + "‰ñ•œ‚·‚é";
    }

    public override void Execute(Vector2Int value)
    {
        HealHpEvent e = Instantiate(healEvent);
        e.heal = value.x;
        e.from = PlayerArea.Instance.player;
        e.target = PlayerArea.Instance.player;
    }
}
