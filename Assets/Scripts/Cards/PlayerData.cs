using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Other/PlayerData", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public List<CardBattleData> deck = new List<CardBattleData>();
    public List<Relic> relic = new List<Relic>();

    [Space]
    public int health;

    public int energy;
    public int drawCard;
    public float shieldClear;
    public int curHealth;
    public int coin;
    public BattleSceneData curBattleSceneData;

    [Header("StartSetting")]
    public CardDatabase cardDatabase;

    public int startHealth;
    public int startEnergy;
    public int startDrawCard;
    public float startShieldClear;
    public int startCoin;

    public static PlayerData Instance { get; private set; }

    private void OnEnable()
    {
        Instance = this;
    }

    public void StartNewGame()
    {
        CreateNewDeck(cardDatabase);
        health = startHealth;
        energy = startEnergy;
        drawCard = startDrawCard;
        shieldClear = startShieldClear;
        curHealth = health;
        coin = startCoin;
        MapData.Instance.StartNewGame();
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