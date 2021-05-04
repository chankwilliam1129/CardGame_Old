using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelectGroup : CardDisplayOnlyGroup
{
    public CardDisplay cardSelectDisplay;
    public List<CardDisplay> cardList;
    public int selectNumber;

    public void Update()
    {
        if (cardList.Count == 0)
        {
            Destroy(gameObject);
        }
    }

    public void Add(CardBattleData data)
    {
        CardDisplay card = Instantiate(cardSelectDisplay, transform);
        card.data = data;
        card.SetUp();

        cardList.Add(card);
    }

    public override void OnPointEnter(CardDisplay card)
    {
        card.GetComponent<Animator>().SetBool("isSelect", true);
    }

    public override void OnPointExit(CardDisplay card)
    {
        card.GetComponent<Animator>().SetBool("isSelect", false);
    }

    public override void OnClick(CardDisplay card)
    {
        BattleDeckManager.Instance.DrawCard(card);
        Destroy(card.gameObject);
        selectNumber--;

        if (selectNumber <= 0)
        {
            Destroy(gameObject);
        }
    }
}