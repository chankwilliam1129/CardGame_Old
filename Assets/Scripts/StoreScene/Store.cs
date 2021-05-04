using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : CardDisplayOnlyGroup
{
    public CardDatabase cardDatabase;
    public CardDisplay[] sellCard = new CardDisplay[5];

    public Button buyButton;
    public Button canselButton;

    public CardDisplay SelectCard;

    private void Start()
    {
        for (int i = 0; i < 5; i++) 
        {
            sellCard[i].data = cardDatabase.cardList[Random.Range(0, cardDatabase.cardList.Count)].battleData;
            sellCard[i].SetUp();
        }
 
        buyButton.gameObject.SetActive(false);
        canselButton.gameObject.SetActive(false);
    }

    public override void OnPointEnter(CardDisplay card) 
    {
        card.GetComponent<Animator>().SetBool("isTouch", true);
    }

    public override void OnPointExit(CardDisplay card)
    {
        card.GetComponent<Animator>().SetBool("isTouch", false);
    }

    public override void OnClick(CardDisplay card)
    {
        SelectCard = card;
        buyButton.gameObject.SetActive(true);
        canselButton.gameObject.SetActive(true);
    }
}
