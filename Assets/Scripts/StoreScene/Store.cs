using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : CardDisplayOnlyGroup
{
    public CardDatabase cardDatabase;
    public CardDisplay[] sellCard = new CardDisplay[5];

    private void Start()
    {
        for (int i = 0; i < 5; i++) 
        {
            sellCard[i].data = cardDatabase.cardList[Random.Range(0, cardDatabase.cardList.Count)].battleData;
            sellCard[i].SetUp();
        }
    }

    public override void OnPointEnter(CardDisplay card) 
    {

    }

    public override void OnPointExit(CardDisplay card)
    {
    }

    public override void OnClick(CardDisplay card)
    {
    }
}
