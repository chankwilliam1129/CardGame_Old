using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/Heal", fileName = "Heal")]
public class Heal : CardEffect
{
    public HealEvent healEvent;

    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return "‘Ì—Í‚ğ" + GetValueString(value, isFinal) + "‰ñ•œ‚·‚éB";
    }

    public override void Execute(Vector2Int value, int power)
    {
        HealEvent e = Instantiate(healEvent, BattleEventManager.Instance.transform);
        e.heal = GetFinalValue(value, power);
        e.target = PlayerArea.Instance.player;
    }
}