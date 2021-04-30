using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCardDisplay : MonoBehaviour
{
    public RectTransform battleDeckUI;
    public CardDisplay cardDisplay;

    public List<CardDisplay> cardDisplayList;

    public float cardSizeX;

    [Space]
    [Header("GameUpdate")]
    public CardDisplay nowDraggingCard;

    public static HandCardDisplay Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void Add(CardBattleData card)
    {
        CardDisplay newCard = Instantiate(cardDisplay, battleDeckUI.position, transform.rotation, transform);
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
        if (nowDraggingCard != null)
        {
            nowDraggingCard.GetComponent<CardEventTrigger>().isDrag = false;
            nowDraggingCard.GetComponent<HandCardElement>().isActivity = true;
            GetComponent<HandCardLayoutGroup>().ElementUpdate();
        }
        nowDraggingCard = card;
        if (nowDraggingCard != null)
        {
            nowDraggingCard.GetComponent<CardEventTrigger>().isDrag = true;
            nowDraggingCard.GetComponent<HandCardElement>().isActivity = false;
            GetComponent<HandCardLayoutGroup>().ElementUpdate();
        }
    }

    public bool IsEmpty()
    {
        return cardDisplayList.Count == 0;
    }
}