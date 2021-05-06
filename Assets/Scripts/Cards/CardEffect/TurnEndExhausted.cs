using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/TurnEndExhausted", fileName = "TurnEndExhausted")]
public class TurnEndExhausted : CardEffect
{
    public RemoveCardOnTurnEnd obj;

    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return "�^�[���I�����ɔp������B";
    }

    public override void Generate(Vector2Int value, CardDisplay cardDisplay)
    {
        cardDisplay.data.removeType = BattleDeckManager.RemoveType.Exhausted;
        Instantiate(obj, cardDisplay.transform);
    }
}