using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/PlayCard", fileName = "PlayCard")]
public class PlayCard : CardEffect
{
    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return "ÉvÉåÉCÇ∑ÇÈÅB";
    }

    public override void Execute(Vector2Int value, int power,CardDisplay cardDisplay)
    {
        CardEffectExecutor.Instance.PlayCard(cardDisplay, power);
    }
}
