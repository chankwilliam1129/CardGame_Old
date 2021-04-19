using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEventTrigger : MonoBehaviour
{
    public CardDisplay cardDisplay;
    public bool isDrag;

    private void Start()
    {
        isDrag = false;
        cardDisplay = GetComponent<CardDisplay>();
    }

    private void Update()
    {
        if (isDrag)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnPointEnter()
    {
        if (!GetComponent<Animator>().GetBool("isMod") && HandCardDisplay.Instance.nowDraggingCard == null)
        {
            GetComponent<HandCardElement>().isFront = true;
            GetComponent<HandCardElement>().SetFlexibleWidth(1.5f);
            GetComponent<Animator>().SetBool("isSelect", true);
        }
    }

    public void OnPointExit()
    {
        if (HandCardDisplay.Instance.nowDraggingCard != cardDisplay)
        {
            GetComponent<HandCardElement>().isFront = false;
            GetComponent<HandCardElement>().SetFlexibleWidth(1.0f);
            GetComponent<Animator>().SetBool("isSelect", false);
        }
    }

    public void OnBeginDrag()
    {
        if (!GetComponent<Animator>().GetBool("isMod"))
        {
            HandCardDisplay.Instance.SetNowDraggingCard(cardDisplay);
            GetComponent<Animator>().SetBool("isDragging", true);
        }
    }

    public void OnEndDrag()
    {
        HandCardDisplay.Instance.SetNowDraggingCard(null);
        GetComponent<HandCardElement>().isFront = false;
        GetComponent<HandCardElement>().SetFlexibleWidth(1.0f);
        GetComponent<Animator>().SetBool("isSelect", false);
        GetComponent<Animator>().SetBool("isDragging", false);
    }

    public void SetModMode()
    {
        if (!GetComponent<Animator>().GetBool("isMod"))
        {
            HandCardDisplay.Instance.nowModCard.Add(cardDisplay);
            GetComponent<Animator>().SetBool("isMod", true);
        }
        else
        {
            HandCardDisplay.Instance.nowModCard.Remove(cardDisplay);
            GetComponent<Animator>().SetBool("isMod", false);
        }
    }
}