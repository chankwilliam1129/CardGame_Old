using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public HandCardDisplay handCardDisplay;

    [Space]
    public TextMeshProUGUI nameText;
    public Image cardImage;
    public Vector3 targetPosition;


    private void Start()
    {
        nameText.text = card.name;
        cardImage.sprite = card.image;
    }

    private void Update()
    {

    }

    public void OnPointEnter()
    {
        GetComponent<Canvas>().sortingOrder += 10;
        GetComponent<Animator>().SetBool("isSelect", true);
    }

    public void OnPointExit()
    {
        GetComponent<Canvas>().sortingOrder -= 10;
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