using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCardDisplay : MonoBehaviour
{
    public BattleDeckManager battleDeck;
    public RectTransform battleDeckUI;
    public CardDisplay cardDisplay;

    public List<CardDisplay> cardDisplayList;

    public float cardSizeX;
    private void Start()
    {
    }

    private void Update()
    {
    }

    public void DrawCard(Card card)
    {
        CardDisplay newCard = Instantiate(cardDisplay, battleDeckUI.position, Quaternion.identity, transform);
        newCard.handCardDisplay = this;
        newCard.card = card;
        cardDisplayList.Add(newCard);
        FixCardDisplayTransform();
    }

    public void Discard(CardDisplay card)
    {
        cardDisplayList.Remove(card);
        battleDeck.discardPile.Add(card.card);
        Destroy(card.gameObject);
        FixCardDisplayTransform();
    }

    private void FixCardDisplayTransform()
    {
        int total = cardDisplayList.Count - 1;
        for (int i = 0; i <= total; i++) 
        {
            Vector3 pos = transform.position;
            pos.x += (i * cardSizeX * transform.lossyScale.x) - (total * cardSizeX * transform.lossyScale.x * 0.5f);
            cardDisplayList[i].targetPosition = pos;
            cardDisplayList[i].GetComponent<Canvas>().sortingOrder = i;
        }
    }
}