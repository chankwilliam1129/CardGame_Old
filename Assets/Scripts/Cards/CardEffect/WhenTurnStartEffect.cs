using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/WhenTurnStart", fileName = "WhenTurnStart")]
public class WhenTurnStartEffect : CardEffect
{
    [SerializeField] public List<CardBattleData.Effect> effects;

    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        string text = "ターン開始時:";
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
        cardDisplay.gameObject.AddComponent<WhenTurnEnd>().effects = effects;
    }
}
