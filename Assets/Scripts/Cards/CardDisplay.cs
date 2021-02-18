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

        if (transform.position != targetPosition)
        {
             transform.position += (targetPosition - transform.position) * 0.1f;
        }
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

    public void OnPointClick()
    {
        handCardDisplay.Discard(this);
    }


    public void OnBeginDrag()
    {
        handCardDisplay.SetNowDraggingCard(this);
    }

    public void OnEndDrag()
    {
        handCardDisplay.SetNowDraggingCard(null);
    }
}