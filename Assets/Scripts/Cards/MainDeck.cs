using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Other/MainDeck", fileName = "MainDeck")]
public class MainDeck : ScriptableObject
{
    public CardDatabase cardDatabase;
    public List<CardBattleData> deck = new List<CardBattleData>();

    public void CreateNewCard()
    {
        deck.Clear();
        for (int i = 0; i < 20; i++)
        {
            deck.Add(cardDatabase.cardList[i].battleData);
        }
    }
}