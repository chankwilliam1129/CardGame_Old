using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/WhenPlayCard", fileName = "WhenPlayCard")]

public class WhenPlayCardEffect : CardEffect
{
    public Card card;
    [SerializeField] public List<CardBattleData.Effect> effects;

    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        
        string text = "";
        if (card != null) text += card.name;
        else text += "任意のカード";
        text += "をプレイする時：";
        text += "<size=80%>\n";

        foreach (var effect in effects)
        {
            text += "  ";
            text += effect.type.GetDescription(new Vector2Int(effect.value.x, 0), isFinal);
            text += "\n";
        }
        text += "</size>";

        return text;
    }

    public override void Generate(Vector2Int value, CardDisplay cardDisplay)
    {
        WhenPlayCard playcard = cardDisplay.gameObject.AddComponent<WhenPlayCard>();
        playcard.effects = effects;
        playcard.card = card;
    }
}
