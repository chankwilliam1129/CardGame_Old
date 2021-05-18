using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/PlayCard", fileName = "PlayCard")]
public class ExtraEffect : CardEffect
{
    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return GetValueString(new Vector2Int(value.x + 1, value.y), isFinal) + "‰ñƒvƒŒƒC‚·‚éB";
    }

    public override void Execute(Vector2Int value, int power, CardDisplay cardDisplay)
    {
        for (int i = GetFinalValue(value, power); i > 0; i--)
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
}
