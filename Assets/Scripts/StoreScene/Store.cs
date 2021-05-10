using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : CardDisplayOnlyGroup
{
    public CardDatabase cardDatabase;
    public CardDisplay[] sellCard = new CardDisplay[5];

    public static Store Instance { get; private set; }

    private Store()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++) 
        {
            sellCard[i].data = cardDatabase.cardList[Random.Range(0, cardDatabase.cardList.Count)].battleData;
            sellCard[i].SetUp();
            sellCard[i].GetComponent<StoreCardDisplay>().priceText.text = "" + sellCard[i].data.preset.price;
            if (sellCard[i].data.preset.price > Wallet.Instance.coin)
            {
                ChangeColor(sellCard[i], new Color(1.0f, 0.0f, 0.3f, 1.0f));
            }
        }
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
        if (Wallet.Instance.coin >= card.data.preset.price)
        {
            Wallet.Instance.coin -= card.data.preset.price;
            TextManager.Instance.coinText.text = "" + Wallet.Instance.coin;

            for (int i = 0; i < 5; i++)
            {
                if (sellCard[i].data.preset.price > Wallet.Instance.coin)
                {
                    ChangeColor(sellCard[i], new Color(1.0f, 0.0f, 0.3f, 1.0f));
                }
            }
            BuyCard(card);
            card.gameObject.SetActive(false);
        }
        else
        {
            TextManager.Instance.notEnoughCoinText.gameObject.SetActive(true);
        }
    }
    private void ChangeColor(CardDisplay card, Color co)
    {
        card.GetComponent<StoreCardDisplay>().priceText.color = new Color(co.r, co.g, co.b, co.a);
    }
    private void BuyCard(CardDisplay card)
    {

    }
}
