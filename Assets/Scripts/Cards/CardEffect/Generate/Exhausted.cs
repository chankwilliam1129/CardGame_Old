using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/Exhausted", fileName = "Exhausted")]
public class Exhausted : CardEffect
{
    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return "è¡îÔÇ∑ÇÈÅB";
    }

    public override void Generate(Vector2Int value, CardDisplay cardDisplay)
    {
        cardDisplay.data.removeType = BattleDeckManager.RemoveType.Exhausted;
    }
}