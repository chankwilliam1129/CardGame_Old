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
    }

    public void ElementUpdate()
    {
        float totalWidth = 0;
        foreach (HandCardElement e in elements)
        {
            if (e.isActivity) totalWidth += e.flexibleWidth;
        }
        float curWidth = 0;
        int order = 0;
        foreach (HandCardElement e in elements)
        {
            if (e.isActivity)
            {
                curWidth += e.flexibleWidth;
                float OffsetX = (curWidth - totalWidth) * 0.5f * width;
                curWidth += e.flexibleWidth;

                Vector3 pos = transform.position;
                pos.x += OffsetX;
                e.MovingTo(pos);

                e.GetComponent<Canvas>().sortingOrder = order;
                order++;
            }
        }
    }
}