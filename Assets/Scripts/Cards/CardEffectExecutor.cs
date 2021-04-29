using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectExecutor : MonoBehaviour
{
    public List<CardDisplay> nowModCard;
    public int totalNormalPower;
    public int totalEmptyPower;
    public int totalBrokenPower;

    public int extraAttackCount;
    public int extraDamage;

    public static CardEffectExecutor Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void Execute()
    {
        if (HandCardDisplay.Instance.nowDraggingCard != null)
        {
            foreach (var effect in HandCardDisplay.Instance.nowDraggingCard.data.playEffects)
            {
                effect.type.Execute(effect.value, totalNormalPower);
            }
            BattleDeckManager.Instance.Discard(HandCardDisplay.Instance.nowDraggingCard, HandCardDisplay.Instance.nowDraggingCard.data.removeType);
            foreach (var card in nowModCard)
            {
                BattleDeckManager.Instance.Discard(card, card.data.removeType);
            }
            nowModCard.Clear();
            CountTotalPower();
        }
    }

    public void AddModCard(CardDisplay card)
    {
        nowModCard.Add(card);
        CountTotalPower();
    }

    public void RemoveModCard(CardDisplay card)
    {
        nowModCard.Remove(card);
        CountTotalPower();
    }

    public void CountTotalPower()
    {
        totalNormalPower = 0;
        totalBrokenPower = 0;
        totalEmptyPower = 0;

        foreach (var c in nowModCard)
        {
            totalNormalPower += c.data.normalPower;
            totalBrokenPower += c.data.brokenPower;
            totalEmptyPower += c.data.emptyPower;
        }

        int totolPower = totalNormalPower + totalBrokenPower + totalEmptyPower;

        foreach (var c in HandCardDisplay.Instance.cardDisplayList)
        {
            c.SetUsable(c.data.powerSpace >= totolPower);
        }

        foreach (var card in HandCardDisplay.Instance.cardDisplayList)
        {
            card.powerSpaceDisplay.PowerDisplayUpdate();
        }
    }
}