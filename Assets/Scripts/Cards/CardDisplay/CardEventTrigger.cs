using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEventTrigger : MonoBehaviour
{
    public CardDisplay cardDisplay;
    private HandCardElement element;
    public bool isBeginDrag;
    public bool isDrag;

    private void Start()
    {
        isDrag = false;
        cardDisplay = GetComponent<CardDisplay>();
        element = GetComponent<HandCardElement>();
    }

    private void Update()
    {
        if (isBeginDrag)
        {
            float posY = Input.mousePosition.y - (HandCardDisplay.Instance.transform.position.y + HandCardDisplay.Instance.GetComponent<RectTransform>().rect.height * 0.5f);

            if (isDrag)
            {
                if (posY < 0.0f)
                {
                    HandCardDisplay.Instance.SetNowDraggingCard(null);
                }
                else
                {
                    if (element.IsMoving()) element.targetPosition = Input.mousePosition;
                    else transform.position = Input.mousePosition;
                }
            }
            else
            {
                if (posY >= 0.0f)
                {
                    HandCardDisplay.Instance.SetNowDraggingCard(cardDisplay);
                    element.MovingTo(Input.mousePosition);
                }
            }
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
        if (!GetComponent<Animator>().GetBool("isMod") && GetComponent<Animator>().GetBool("isUsable"))
        {
            isBeginDrag = true;
            GetComponent<Animator>().SetBool("isDragging", true);
        }
    }

    public void OnEndDrag()
    {
        if (isDrag)
        {
            CardEffectExecutor.Instance.Execute();
            HandCardDisplay.Instance.SetNowDraggingCard(null);
        }
        else
        {
            isBeginDrag = false;
            GetComponent<HandCardElement>().isFront = false;
            GetComponent<HandCardElement>().SetFlexibleWidth(1.0f);
            GetComponent<Animator>().SetBool("isSelect", false);
            GetComponent<Animator>().SetBool("isDragging", false);
        }
    }

    public void SetModMode()
    {
        if (!GetComponent<Animator>().GetBool("isMod"))
        {
            CardEffectExecutor.Instance.AddModCard(cardDisplay);
            GetComponent<Animator>().SetBool("isMod", true);
        }
        else
        {
            CardEffectExecutor.Instance.RemoveModCard(cardDisplay);
            GetComponent<Animator>().SetBool("isMod", false);
        }
    }
}