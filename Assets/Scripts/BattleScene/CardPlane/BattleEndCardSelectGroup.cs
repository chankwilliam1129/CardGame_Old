using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEndCardSelectGroup : CardDisplayOnlyGroup
{
    public List<CardDisplay> cardList;
    public int selectNumber;
    public CardRemove cardRemove;

    private void Start()
    {
    }

    private void Update()
    {
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
        Instantiate(cardRemove, BattleEventManager.Instance.transform).SetUp(card);
        PlayerData.Instance.deck.Add(card.data);
        cardList.Remove(card);
        Destroy(card.gameObject);
        selectNumber--;

        if (selectNumber <= 0)
        {
            foreach (var c in cardList)
            {
                Destroy(c.gameObject);
            }
            cardList.Clear();
        }
    }
}