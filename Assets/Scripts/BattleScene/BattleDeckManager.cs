using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDeckManager : MonoBehaviour
{
    public BattleStateManager battleState;
    public BattleEventManager battleEvent;

    public MainDeck mainDeck;
    public HandCardDisplay handCardDisplay;
    public List<Card> battleDeck;
    public List<Card> discardPile;



    public enum DrawType
    {
        FromBattleDeck,
        FromDiscardPile,
        ByCreating,
    }
    public event EventHandler<DrawType> OnAddCardToHand;

    public enum RemoveType
    {
        ToDiscardPile,
        Destory,
    }
    public event EventHandler<RemoveType> OnRemoveCardFromHand;

    void Start()
    {
        battleState.OnBattleStart += BattleDeckInit;
        battleState.OnPlayerTurnStart += TurnStartDrawCard;
    }


    private void BattleDeckInit(object sender, System.EventArgs e)
    {
        mainDeck.CreateNewCard();
        battleDeck = new List<Card>(mainDeck.deck);
        ShuffleDeck(battleDeck);
        discardPile = new List<Card>();
    }

    private void TurnStartDrawCard(object sender, System.EventArgs e)
    {
        while (handCardDisplay.cardDisplayList.Count < 5)
        {
            DrawCard(DrawType.FromBattleDeck);
        }
    }


    void Update()
    {
    }


    public void DrawCard(DrawType type)
    {
        switch(type)
        {
            case DrawType.FromBattleDeck:
                if (battleDeck.Count == 0)
                {
                    battleDeck = new List<Card>(discardPile);
                    ShuffleDeck(battleDeck);
                    discardPile.Clear();
                }

                handCardDisplay.Add(battleDeck[0]);
                battleDeck.Remove(battleDeck[0]);
                break;

            default:
                break;
        }

        OnAddCardToHand?.Invoke(this, type);
    }

    public void Discard(CardDisplay cardDisplay,RemoveType type)
    {

        switch (type)
        {
            case RemoveType.ToDiscardPile:
                discardPile.Add(cardDisplay.card);
                break;

            default:
                break;
        }

        handCardDisplay.Remove(cardDisplay);
        OnRemoveCardFromHand?.Invoke(this, type);
    }


    public void ShuffleDeck(List<Card> cards)
    {
        for(int i = 0;i<cards.Count;i++)
        {
            int r = UnityEngine.Random.Range(i, cards.Count);
            Card temp = cards[i];
            cards[i] = cards[r];
            cards[r] = temp;
        }
    }

}
