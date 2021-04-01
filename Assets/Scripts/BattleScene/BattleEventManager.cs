using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEventManager : MonoBehaviour
{
    public CardSlot slot;

    public int normalPower;
    public int emptyPower;
    public int brokenPower;

    public int dealDamage;
    public int drawCard;

    public void PlayCard(CardSlot slot)
    {
        foreach (CardDisplay card in slot.power)
        {
            normalPower += card.data.normalPower;
            emptyPower += card.data.emptyPower;
            brokenPower += card.data.brokenPower;
        }

        foreach (CardBattleData.Effect effect in slot.card.data.playEffects)
        {
            effect.type.OnStart(effect.value, this);
        }

        foreach (CardDisplay mod in slot.power)
        {
            foreach (CardBattleData.Effect effect in mod.data.modEffects)
            {
                effect.type.OnStart(effect.value, this);
            }
        }

        Debug.Log("dealDamage" + dealDamage);
        CardEffectEnd();
    }

    public void CardEffectEnd()
    {
        normalPower = 0;
        emptyPower = 0;
        brokenPower = 0;
        dealDamage = 0;
        drawCard = 0;
    }
}