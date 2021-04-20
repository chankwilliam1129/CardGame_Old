using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Other/CardDatabase", fileName = "CardDatabase")]
public class CardDatabase : ScriptableObject
{
    public List<Card> cardList = new List<Card>();
}