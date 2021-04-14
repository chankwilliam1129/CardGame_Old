using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEventTrigger : MonoBehaviour
{
    public CardDisplay cardDisplay;

    private void Start()
    {
        cardDisplay = GetComponent<CardDisplay>();
    }

    public void OnPointEnter()
    {
        if (!GetComponent<Animator>().GetBool("isMod"))
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
        if (!GetComponent<Animator>().GetBool("isMod"))
        {
            HandCardDisplay.Instance.SetNowDraggingCard(cardDisplay);
            GetComponent<Animator>().SetBool("isDragging", true);
        }
    }

    public void OnEndDrag()
    {
        HandCardDisplay.Instance.SetNowDraggingCard(null);
        HandCardDisplay.Instance.DragArrow.SetActive(false);
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