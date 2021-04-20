using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/DrawCard", fileName = "DrawCard")]
public class DrawCard : CardEffect
{
    public GameObject drawCardEvent;

    public override string GetDescription(Vector2Int value)
    {
        return value.x.ToString() + "–‡ƒJ[ƒh‚ğˆø‚­";
    }

    public override void Execute(Vector2Int value)
    {
        for (int i = 0; i < value.x; i++)
        {
            Instantiate(drawCardEvent);
        }
    }
}