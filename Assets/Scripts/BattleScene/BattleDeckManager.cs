using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public event EventHandler<DrawType> OnAddCardToHand;

    public enum RemoveType
    {
        ToDiscardPile,
        Destory,
    }

    public event EventHandler<RemoveType> OnRemoveCardFromHand;

    public static BattleDeckManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        BattleStateManager.Instance.OnBattleStart += BattleDeckInit;
        BattleStateManager.Instance.OnPlayerTurnStart += TurnStartDrawCard;
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
            for(int i=0;i<num;i++)
            {
                Instantiate(drawCardEvent);
            }
        }
    }

    private void Update()
    {
    }

    public void DrawCard(DrawType type)
    {
        switch (type)
        {
            case DrawType.FromBattleDeck:
                if (battleDeck.Count == 0)
                {
                    battleDeck = new List<CardBattleData>(discardPile);
                    ShuffleDeck(battleDeck);
                    discardPile.Clear();
                }

                HandCardDisplay.Instance.Add(battleDeck[0]);
                battleDeck.Remove(battleDeck[0]);
                break;

            default:
                break;
        }

        OnAddCardToHand?.Invoke(this, type);
    }

    public void Discard(CardDisplay cardDisplay, RemoveType type)
    {
        switch (type)
        {
            case RemoveType.ToDiscardPile:
                discardPile.Add(cardDisplay.data);
                break;

            default:
                break;
        }

        HandCardDisplay.Instance.Remove(cardDisplay);
        OnRemoveCardFromHand?.Invoke(this, type);
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