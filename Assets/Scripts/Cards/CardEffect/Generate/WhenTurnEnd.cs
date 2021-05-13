using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WhenTurnEnd : CardGenerate
{
    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        string text = "É^Å[ÉìèIóπéû:";
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

    public override CardGenerate SetUp(CardDisplay cardDisplay)
    {
        return cardDisplay.gameObject.AddComponent<WhenTurnEnd>();
    }

    private void Start()
    {
        PlayerArea.Instance.player.characterEvent.OnTurnEnd += TurnEnd;
    }

    private void OnDestroy()
    {
        PlayerArea.Instance.player.characterEvent.OnTurnEnd -= TurnEnd;
    }

    private void TurnEnd(object sender, System.EventArgs e)
    {

        foreach (var effect in effects)
        {
            effect.type.Execute(effect.value, 0, GetComponent<CardDisplay>());
        }
        
    }
}