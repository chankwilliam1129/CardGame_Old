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

    [Space]
    public TextMeshProUGUI nameText;
    public Image cardImage;

    void Start()
    {
        DeleteCard();
    }
    void Update()
    {
    }

    public void InputCard(CardDisplay card)
    {
        nameText.text = card.card.name;
        cardImage.color = Color.white;
        cardImage.sprite = card.card.image;
    }

    public void DeleteCard()
    {
        nameText.text = "";
        cardImage.sprite = null;
        cardImage.color = Color.clear;
    }

    public void OnPointerUp()
    {
        Debug.Log("Up");
        if(handCard.nowDraggingCard != null)
        {
            InputCard(handCard.nowDraggingCard);
        }
    }
}
