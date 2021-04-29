using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/DrawCard", fileName = "DrawCard")]
public class DrawCard : CardEffect
{
    public GameObject drawCardEvent;

    public override string GetDescription(Vector2Int value)
    {
        return GetValueString(value) + "枚カードを引く。";
    }

    public override void Execute(Vector2Int value, int power)
    {
        int draw = GetFinalValue(value, power);
        for (int i = 0; i < draw; i++)
        {
            Instantiate(drawCardEvent, BattleEventManager.Instance.transform);
        }
    }
}