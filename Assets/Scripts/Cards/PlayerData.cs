using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Other/PlayerData", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public List<CardBattleData> deck = new List<CardBattleData>();
    public List<Relic> relic = new List<Relic>();

    public int health;
    public int energy;
    public int drawCard;
    public float shieldClear;

    [Space]
    public int curHealth;

    public int coin;

    public BattleSceneData curBattleSceneData;

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