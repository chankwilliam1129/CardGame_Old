using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplayOnlyEventTrigger : MonoBehaviour
{
    private CardDisplay card;
    private CardDisplayOnlyGroup group;

    private void Start()
    {
        card = GetComponent<CardDisplay>();
        group = transform.parent.GetComponent<CardDisplayOnlyGroup>();
    }

    public void OnPointEnter()
    {
        group?.OnPointEnter(card);
    }

    public void OnPointExit()
    {
        group?.OnPointExit(card);
    }

    public void OnClick()
    {
        group?.OnClick(card);
    }
}