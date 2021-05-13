using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/RemoveCard", fileName = "RemoveCard")]
public class RemoveCard : CardEffect
{
    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return "è¡îÔÇ∑ÇÈÅB";
    }

    public override void Execute(Vector2Int value, int power, CardDisplay cardDisplay)
    {
        BattleDeckManager.Instance.Remove(cardDisplay);
    }
}
