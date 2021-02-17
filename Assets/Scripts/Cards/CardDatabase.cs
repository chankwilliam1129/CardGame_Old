using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardDatabase : ScriptableObject
{
    public List<Card> cardList = new List<Card>();
}