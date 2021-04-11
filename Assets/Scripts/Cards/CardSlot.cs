using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardSlot : MonoBehaviour
{
    public BattleDeckManager battleDeck;
    public EnemyArea enemyArea;

    [Space]
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
        //if (this.card == null)
        //{
        gameObject.SetActive(true);
        card.OnInputSlot();
        this.card = card;
        nameText.text = card.data.preset.name;
        cardImage.color = Color.white;
        cardImage.sprite = card.data.preset.image;
        //}
        //else
        //{
        //    int curPower = card.data.brokenPower + card.data.emptyPower + card.data.normalPower;
        //    foreach (CardDisplay c in power)
        //    {
        //        curPower += c.data.emptyPower;
        //        curPower += c.data.normalPower;
        //        curPower += c.data.brokenPower;
        //    }

        //    if (curPower <= this.card.data.powerSpace)
        //    {
        //        card.OnInputSlot();
        //        power.Add(card);
        //    }
        //    else Debug.Log("PowerFull");
        //}
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
        battleDeck.battleEvent.PlayCard(this);

        if (card != null)
        {
            battleDeck.Discard(card, BattleDeckManager.RemoveType.ToDiscardPile);
            foreach (CardDisplay c in power)
            {
                battleDeck.Discard(c, BattleDeckManager.RemoveType.ToDiscardPile);
            }
        }
        DeleteCard();
    }

    public void OnCancel()
    {
    }
}