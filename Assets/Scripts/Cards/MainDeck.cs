using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MainDeck : ScriptableObject
{
    public CardDatabase cardDatabase;
    public List<Card> deck = new List<Card>();

    private int randomNumber;

    public void CreateNewCard()
    {
        deck.Clear();
        for (int i = 0; i < 20; i++)
        {
            randomNumber = Random.Range(0, cardDatabase.cardList.Count);
            deck.Add(cardDatabase.cardList[randomNumber]);
        }
    }

}