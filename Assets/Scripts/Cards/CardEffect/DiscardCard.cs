using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/DiscardCard", fileName = "DiscardCard")]
public class DiscardCard : CardEffect
{
    public DiscardCardEvent discardCardEvent;

    public override string GetDescription(Vector2Int value)
    {
        return GetValueString(value) + "枚カードを廃棄する。";
    }

    public override void Execute(Vector2Int value, int power)
    {
        int discard = GetFinalValue(value, power);
        if (discard > 0)
        {
            Instantiate(discardCardEvent, BattleEventManager.Instance.transform).discardNumber = discard;
        }
    }
}