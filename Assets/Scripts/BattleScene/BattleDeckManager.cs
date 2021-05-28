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
    public CardDatabase cardDatabase;

    public List<CardBattleData> battleDeck;
    public List<CardBattleData> discardPile;

    public BattleEvent drawCardEvent;

    public CardRemove cardRemove;

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
        OnAddCardToHand += HandCardLimitCheck;
    }

    private void HandCardLimitCheck(object sender, EventArgs e)
    {
        if(HandCardDisplay.Instance.cardDisplayList.Count >10)
        {
            CardEventArgs args = e as CardEventArgs;
            Discard(args.card);
        }
    }

    private void OnDestroy()
    {
        BattleStateManager.Instance.OnBattleStart -= BattleDeckInit;
        BattleStateManager.Instance.OnPlayerTurnStart -= TurnStartDrawCard;
    }

    private void BattleDeckInit(object sender, System.EventArgs e)
    {
        PlayerData.Instance.CreateNewDeck(cardDatabase);
        battleDeck = new List<CardBattleData>(PlayerData.Instance.deck);
        ShuffleDeck(battleDeck);
        discardPile = new List<CardBattleData>();
    }

    private void TurnStartDrawCard(object sender, System.EventArgs e)
    {
        Debug.Log("Player Draw Card");

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
        CardEventArgs args = new CardEventArgs(HandCardDisplay.Instance.Add(card.data));
        OnAddCardToHand?.Invoke(this, args);
    }

    public void DrawCard(CardDisplay card, Vector3 pos)
    {
        CardEventArgs args = new CardEventArgs(HandCardDisplay.Instance.Add(card.data, pos));
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

        Instantiate(cardRemove, cardDisplay.transform.position, cardDisplay.transform.rotation, BattleEventManager.Instance.transform).cardDisplay.data = cardDisplay.data;
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