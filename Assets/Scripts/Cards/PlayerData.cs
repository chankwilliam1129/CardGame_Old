using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Other/PlayerData", fileName = "PlayerData")]
public class PlayerData: ScriptableObject
{
    public CardDatabase cardDatabase;
    public List<CardBattleData> deck = new List<CardBattleData>();
    public List<Relic> relic  = new List<Relic>();

    public static PlayerData Instance { get; private set; }

    private void OnEnable()
    {
        Instance = this;
    }


    public void CreateNewDeck()
    {
        deck.Clear();
        for (int i = 0; i < 20; i++)
        {
            deck.Add(cardDatabase.cardList[i].battleData);
        }
    }
}