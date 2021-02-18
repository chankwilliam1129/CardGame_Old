using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardSlot : MonoBehaviour
{
    public HandCardDisplay handCard;

    [Space]
    public CardDisplay card;
    public List<CardDisplay> power;

    [Space]
    public TextMeshProUGUI nameText;
    public Image cardImage;

    public event EventHandler OnSlotChange;

    void Start()
    {
        DeleteCard();
    }
    void Update()
    {
    }

    public void InputCard(CardDisplay card)
    {
        if (this.card == null)
        {
            this.card = card;
            nameText.text = card.card.name;
            cardImage.color = Color.white;
            cardImage.sprite = card.card.image;
        }
        else
        {
            int curPower = card.card.brokenPower + card.card.emptyPower + card.card.normalPower;
            foreach (CardDisplay c in power)
            {
                curPower += c.card.emptyPower;
                curPower += c.card.normalPower;
                curPower += c.card.brokenPower;
            }

            if (curPower <= this.card.card.powerSpace) power.Add(card);
            else Debug.Log("PowerFull");
        }
        OnSlotChange?.Invoke(this, EventArgs.Empty);
    }

    public void DeleteCard()
    {
        card = null;
        nameText.text = "";
        cardImage.sprite = null;
        cardImage.color = Color.clear;
        power.Clear();
    }

    public void OnDrop()
    {
        if(handCard.nowDraggingCard != null)
        {
            InputCard(handCard.nowDraggingCard);
        }
    }
}
