using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/Heal", fileName = "Heal")]
public class Heal : CardEffect
{
    public HealEvent healEvent;

    public override string GetDescription(Vector2Int value)
    {
        if (value.y != 0) return value.x.ToString() + "(" + value.y.ToString() + ")体力を回復する。";
        return value.x.ToString() + "体力を回復する。";
    }

    public override void Execute(Vector2Int value, int power)
    {
        HealEvent e = Instantiate(healEvent, BattleEventManager.Instance.transform);
        e.heal = value.x + value.y * power;
        e.target = PlayerArea.Instance.player;
    }
}