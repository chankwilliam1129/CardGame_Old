using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDisplayOnlyEventTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private CardDisplay card;
    private CardDisplayOnlyGroup group;

    private void Start()
    {
        card = GetComponent<CardDisplay>();
        group = transform.parent.GetComponent<CardDisplayOnlyGroup>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        group?.OnPointEnter(card);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        group?.OnPointExit(card);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            group?.OnClick(card);
        }
    }
}