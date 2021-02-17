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

    [SpaceAttribute]
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
        if(transform.position != targetPosition)
        {
            transform.position += (targetPosition - transform.position) * 0.1f;
        }
    }

    public void OnPointEnter()
    {
        transform.localScale = new Vector3(1.3f, 1.3f);
        GetComponent<Canvas>().sortingOrder += 10;
    }

    public void OnPointExit()
    {
        transform.localScale = new Vector3(1.0f, 1.0f);
        GetComponent<Canvas>().sortingOrder -= 10;
    }

    public void OnPointClick()
    {
        handCardDisplay.Discard(this);
    }
}