using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpaceDisplay : MonoBehaviour
{
    public CardDisplay card;
    public PowerDisplay powerDisplay;
    public Object powerSpaceIcon;

    private void Start()
    {
        for (int i = 0; i < card.data.powerSpace; i++)
        {
            Vector3 pos = transform.position;
            pos.x += (card.data.powerSpace * -10f * card.transform.lossyScale.x) + (i + 0.5f) * 20f * card.transform.lossyScale.x;
            Instantiate(powerSpaceIcon, pos, Quaternion.identity, transform);
        }
    }
}