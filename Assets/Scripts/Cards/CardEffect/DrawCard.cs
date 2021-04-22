using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/DrawCard", fileName = "DrawCard")]
public class DrawCard : CardEffect
{
    public GameObject drawCardEvent;

    public override string GetDescription(Vector2Int value)
    {
        if (value.y != 0) return value.x.ToString() + "(" + value.y.ToString() + ")枚カードを引く。";
        else return value.x.ToString() + "枚カードを引く。";
    }

    public override void Execute(Vector2Int value, int power)
    {
        int draw = value.x + value.y * power;
        for (int i = 0; i < draw; i++)
        {
            Instantiate(drawCardEvent);
        }
    }
}