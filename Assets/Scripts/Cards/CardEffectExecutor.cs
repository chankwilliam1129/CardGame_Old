using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectExecutor : MonoBehaviour
{
    public List<CardDisplay> nowModCard;
    public int totalNormalPower;
    public int totalEmptyPower;
    public int totalBrokenPower;

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
                effect.type.Execute(effect.value);
            }
            BattleDeckManager.Instance.Discard(HandCardDisplay.Instance.nowDraggingCard, BattleDeckManager.RemoveType.ToDiscardPile);
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
    }
}