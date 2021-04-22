using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/HealEnergy", fileName = "HealEnergy")]

public class HealEnergy : CardEffect
{
    public HealEnergyEvent healEvent;

    public override string GetDescription(Vector2Int value)
    {
        if (value.y != 0) return value.x.ToString() + "(" + value.y.ToString() + ")�G�i�W�[���񕜂���B";
        return value.x.ToString() + "�G�i�W�[���񕜂���B";
    }

    public override void Execute(Vector2Int value, int power)
    {
        HealEnergyEvent e = Instantiate(healEvent, BattleEventManager.Instance.transform);
        e.heal = value.x;// + value.y * power;
        e.target = PlayerArea.Instance.player;
    }
}
