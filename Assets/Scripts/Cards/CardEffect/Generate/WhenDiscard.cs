using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenDiscard : CardGenerate
{
    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        string text = "�̂Ă鎞:";
        text += "<size=80%>\n";

        foreach (var effect in effects)
        {
            text += "  ";
            text += effect.type.GetDescription(new Vector2Int(effect.value.x,0), isFinal);
            text += "\n";
        }
        text += "</size>";

        return text;
    }

    public override CardGenerate SetUp(CardDisplay cardDisplay)
    {
        return cardDisplay.gameObject.AddComponent<WhenDiscard>();
    }

    private void Start()
    {
        BattleDeckManager.Instance.OnDiscardCard += OnDiscard;
    }

    private void OnDiscard(object sender, System.EventArgs e)
    {
        CardEventArgs cardEventArgs = e as CardEventArgs;
        if(cardEventArgs.card == GetComponent<CardDisplay>())
        {
            foreach (var effect in effects)
            {
                effect.type.Execute(effect.value, 0, cardEventArgs.card);
            }
        }
    }

    private void OnDestroy()
    {
        BattleDeckManager.Instance.OnDiscardCard -= OnDiscard;
    }

    
}
