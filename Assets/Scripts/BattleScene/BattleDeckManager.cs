using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEventArgs : EventArgs
{
    public CardDisplay card { set; get; }

    public CardEventArgs(CardDisplay c)
    {
        card = c;
    }
}

public class BattleDeckManager : MonoBehaviour
{
    public MainDeck mainDeck;
    public List<CardBattleData> battleDeck;
    public List<CardBattleData> discardPile;

    public BattleEvent drawCardEvent;

    public enum DrawType
    {
        FromBattleDeck,
        FromDiscardPile,
        ByCreating,
    }

    public event EventHandler OnAddCardToHand;

    public enum RemoveType
    {
        Discard,
        Exhausted,
    }

    public event EventHandler OnRemoveCard;

    public event EventHandler OnDiscardCard;

    public static BattleDeckManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        BattleStateManager.Instance.OnBattleStart += BattleDeckInit;
        BattleStateManager.Instance.OnPlayerTurnStart += TurnStartDrawCard;

        OnRemoveCard += BattleDeckManager_OnRemoveCard;
    }

    private void BattleDeckManager_OnRemoveCard(object sender, EventArgs e)
    {
        CardEventArgs card = e as CardEventArgs;
        card.card.data.powerSpace = 10;
    }

    private void OnDestroy()
    {
        BattleStateManager.Instance.OnBattleStart -= BattleDeckInit;
        BattleStateManager.Instance.OnPlayerTurnStart -= TurnStartDrawCard;
    }

    private void BattleDeckInit(object sender, System.EventArgs e)
    {
        mainDeck.CreateNewCard();
        battleDeck = new List<CardBattleData>(mainDeck.deck);
        ShuffleDeck(battleDeck);
        discardPile = new List<CardBattleData>();
    }

    private void TurnStartDrawCard(object sender, System.EventArgs e)
    {
        int num = 5 - HandCardDisplay.Instance.cardDisplayList.Count;
        if (num > 0)
        {
            for (int i = 0; i < num; i++)
            {
                Instantiate(drawCardEvent, BattleEventManager.Instance.transform);
            }
        }
    }

    private void Update()
    {
    }

    public void DrawCard()
    {
        if (battleDeck.Count == 0)
        {
            battleDeck = new List<CardBattleData>(discardPile);
            ShuffleDeck(battleDeck);
            discardPile.Clear();
        }

        CardDisplay card = HandCardDisplay.Instance.Add(battleDeck[0]);
        card.data.drawType = DrawType.FromBattleDeck;
        battleDeck.Remove(battleDeck[0]);

        CardEventArgs args = new CardEventArgs(card);
        OnAddCardToHand?.Invoke(this, args);
    }

    public void DrawCard(CardDisplay card)
    {
        HandCardDisplay.Instance.Add(card.data);
        CardEventArgs args = new CardEventArgs(card);
        OnAddCardToHand?.Invoke(this, args);
    }

    public void Remove(CardDisplay cardDisplay)
    {
        CardEventArgs args = new CardEventArgs(cardDisplay);
        OnRemoveCard?.Invoke(this, args);

        switch (args.card.data.removeType)
        {
            case RemoveType.Discard:
                discardPile.Add(args.card.data);
                break;

            default:
                break;
        }

        HandCardDisplay.Instance.Remove(args.card);
    }

    public void Discard(CardDisplay cardDisplay)
    {
        CardEventArgs args = new CardEventArgs(cardDisplay);
        OnDiscardCard?.Invoke(this, args);
        Remove(args.card);
    }

    public void ShuffleDeck(List<CardBattleData> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int r = UnityEngine.Random.Range(i, cards.Count);
            CardBattleData temp = cards[i];
            cards[i] = cards[r];
            cards[r] = temp;
        }
    }
}