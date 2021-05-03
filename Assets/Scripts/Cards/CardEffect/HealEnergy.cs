using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/HealEnergy", fileName = "HealEnergy")]
public class HealEnergy : CardEffect
{
    public HealEnergyEvent healEvent;

    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return "エナジーを" + GetValueString(value, isFinal) + "回復する";
    }

    public override void Execute(Vector2Int value, int power)
    {
        HealEnergyEvent e = Instantiate(healEvent, BattleEventManager.Instance.transform);
        e.heal = GetFinalValue(value, power);
        e.target = PlayerArea.Instance.player;
    }
}