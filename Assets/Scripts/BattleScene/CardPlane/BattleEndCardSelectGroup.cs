using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEndCardSelectGroup : CardDisplayOnlyGroup
{
    public List<CardDisplay> cardList;
    public int selectNumber;


    void Start()
    {
        
    }

    void Update()
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
        PlayerData.Instance.deck.Add(card.data);
        cardList.Remove(card);
        Destroy(card.gameObject);
        selectNumber--;

        if (selectNumber <= 0)
        {

        }
    }
}
