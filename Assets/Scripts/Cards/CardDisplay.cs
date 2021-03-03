using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public CardBattleData data;
    public HandCardDisplay handCardDisplay;

    [Space]
    public TextMeshProUGUI nameText;

    public Image cardImage;
    public Vector3 targetPosition;

    private void Start()
    {
        nameText.text = data.preset.name;
        cardImage.sprite = data.preset.image;
    }

    private void Update()
    {
    }

    public void OnPointEnter()
    {
        if (!GetComponent<Animator>().GetBool("isSlot"))
        {
            GetComponent<HandCardElement>().SetFlexibleWidth(1.5f);
        }
        GetComponent<Canvas>().sortingOrder += 10;
        GetComponent<Animator>().SetBool("isSelect", true);
    }

    public void OnPointExit()
    {
        GetComponent<HandCardElement>().SetFlexibleWidth(1.0f);
        GetComponent<Animator>().SetBool("isSelect", false);
    }

    public void OnBeginDrag()
    {
        if (!GetComponent<Animator>().GetBool("isSlot"))
        {
            handCardDisplay.SetNowDraggingCard(this);
            GetComponent<Animator>().SetBool("isDragging", true);
        }
    }

    public void OnEndDrag()
    {
        handCardDisplay.SetNowDraggingCard(null);
        handCardDisplay.DragArrow.SetActive(false);
        GetComponent<Animator>().SetBool("isDragging", false);
    }

    public void OnInputSlot()
    {
        GetComponent<Animator>().SetBool("isSlot", true);
    }
}