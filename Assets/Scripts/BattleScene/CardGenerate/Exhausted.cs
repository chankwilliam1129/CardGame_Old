using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhausted : CardGenerate
{
    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return "�����B";
    }

    public override void SetUp(CardDisplay cardDisplay)
    {
        cardDisplay.data.removeType = BattleDeckManager.RemoveType.Exhausted;
    }
}