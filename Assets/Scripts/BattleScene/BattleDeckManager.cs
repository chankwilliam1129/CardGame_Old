using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDeckManager : MonoBehaviour
{
    public BattleStateManager battleState;

    public MainDeck mainDeck;
    public HandCardDisplay handCardDisplay;
    public List<Card> battleDeck;
    public List<Card> discardPile;

    void Start()
    {
        battleState.OnBattleStart += BattleState_OnBattleStart;
        battleState.OnPlayerTurnStart += BattleState_OnPlayerTurnStart;
    }


    private void BattleState_OnBattleStart(object sender, System.EventArgs e)
    {
        mainDeck.CreateNewCard();
        battleDeck = new List<Card>(mainDeck.deck);
        ShuffleDeck(battleDeck);
        discardPile = new List<Card>();
    }

    private void BattleState_OnPlayerTurnStart(object sender, System.EventArgs e)
    {
        while (handCardDisplay.cardDisplayList.Count < 5)
        {
            DrawCardFromBattleDeckTop();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            DrawCardFromBattleDeckTop();
        }
    }

    public void DrawCardFromBattleDeckTop()
    {
        if(battleDeck.Count ==0)
        {
            battleDeck = new List<Card>(discardPile);
            ShuffleDeck(battleDeck);
            discardPile.Clear();
        }

        handCardDisplay.DrawCard(battleDeck[0]);
        battleDeck.Remove(battleDeck[0]);
    }

    public void ShuffleDeck(List<Card> cards)
    {
        for(int i = 0;i<cards.Count;i++)
        {
            int r = Random.Range(i, cards.Count);
            Card temp = cards[i];
            cards[i] = cards[r];
            cards[r] = temp;
        }
    }

}
