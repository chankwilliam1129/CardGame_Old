using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCardDisplay : MonoBehaviour
{
    public BattleDeckManager battleDeck;
    public RectTransform battleDeckUI;
    public CardDisplay cardDisplay;
    public GameObject DragArrow;

    public List<CardDisplay> cardDisplayList;

    public float cardSizeX;

    [Space]
    [Header("GameUpdate")]
    public CardDisplay nowDraggingCard;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void Add(CardBattleData card)
    {
        CardDisplay newCard = Instantiate(cardDisplay, transform);
        newCard.handCardDisplay = this;
        newCard.data = card;
        cardDisplayList.Add(newCard);
    }

    public void Remove(CardDisplay card)
    {
        cardDisplayList.Remove(card);
        Destroy(card.gameObject);
    }

    public void SetNowDraggingCard(CardDisplay card)
    {
        nowDraggingCard = card;
        if (card != null)
        {
            DragArrow.SetActive(true);
            DragArrow.transform.position = card.transform.position;
        }
    }
}