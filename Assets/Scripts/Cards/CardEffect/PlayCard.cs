using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/PlayCard", fileName = "PlayCard")]
public class PlayCard : CardEffect
{
    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return GetValueString(value, isFinal) + "âÒÉvÉåÉCÇ∑ÇÈÅB";
    }

    public override void Execute(Vector2Int value, int power,CardDisplay cardDisplay)
    {
        foreach (var effect in cardDisplay.data.effects)
        {
            if (effect.type != this)
            {
                effect.type.Execute(effect.value, power, cardDisplay);
            }
        }
    }
}
