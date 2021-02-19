using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCardLayoutGroup : MonoBehaviour
{
    public BattleDeckManager battleDeck;
    public List<HandCardElement> elements;

    public float width;
    public float speed;

    private void Start()
    {
        battleDeck.OnAddCardToHand += BattleDeck_OnAddCardToHand;
        battleDeck.OnRemoveCardFromHand += BattleDeck_OnRemoveCardFromHand;
    }

    private void BattleDeck_OnRemoveCardFromHand(object sender, BattleDeckManager.RemoveType e)
    {
        Invoke("ElementUpdate",0.05f);
    }

    private void BattleDeck_OnAddCardToHand(object sender, BattleDeckManager.DrawType e)
    {
        Invoke("ElementUpdate", 0.05f);
    }

    private void ElementUpdate()
    {
        float totalWidth = 0;
        foreach (HandCardElement e in elements) totalWidth += e.FlexibleWidth;

        float curWidth = 0;
        foreach (HandCardElement e in elements)
        {
            Vector3 pos = transform.position;
            curWidth += e.FlexibleWidth;
            float OffsetX = (curWidth - totalWidth * 0.5f) * width;
            pos.x += OffsetX;

            e.SetMovingStart(pos);
        }
    }

}
