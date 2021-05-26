using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Other/PlayerData", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public List<CardBattleData> deck = new List<CardBattleData>();
    public List<Relic> relic = new List<Relic>();

    public int coin;

    public static PlayerData Instance { get; private set; }

    private void OnEnable()
    {
        Instance = this;
    }

    public void CreateNewDeck(CardDatabase cardDatabase)
    {
        deck.Clear();
        foreach (var c in cardDatabase.cardList)
        {
            deck.Add(c.battleData);
        }
    }
}