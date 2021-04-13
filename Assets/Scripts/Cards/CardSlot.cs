using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardSlot : MonoBehaviour
{
    public CardDisplay card;

    public Character character;

    public List<CardDisplay> power;

    [Space]
    public TextMeshProUGUI nameText;

    public Image cardImage;

    public event EventHandler OnSlotChange;

    private void Start()
    {
        DeleteCard();
    }

    private void Update()
    {
    }

    public void InputCard(CardDisplay card)
    {
        gameObject.SetActive(true);
        card.OnInputSlot();
        this.card = card;
        nameText.text = card.data.preset.name;
        cardImage.color = Color.white;
        cardImage.sprite = card.data.preset.image;
        OnSlotChange?.Invoke(this, EventArgs.Empty);
    }

    public void DeleteCard()
    {
        card = null;
        nameText.text = "";
        cardImage.sprite = null;
        cardImage.color = Color.clear;
        power.Clear();

        OnSlotChange?.Invoke(this, EventArgs.Empty);
    }

    public void OnUse()
    {
        if (card != null)
        {
            BattleDeckManager.Instance.Discard(card, BattleDeckManager.RemoveType.ToDiscardPile);
            foreach (CardDisplay c in power)
            {
                BattleDeckManager.Instance.Discard(c, BattleDeckManager.RemoveType.ToDiscardPile);
            }
        }
        DeleteCard();
    }

    public void OnCancel()
    {
    }
}