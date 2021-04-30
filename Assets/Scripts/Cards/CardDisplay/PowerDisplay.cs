using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerDisplay : MonoBehaviour
{
    public CardDisplay card;

    public Image emptyPowerIcon;
    public Image normalPowerIcon;
    public Image brokenPowerIcon;

    private void Start()
    {
    }

    public void SetUp()
    {
        int maxPower = card.data.emptyPower + card.data.normalPower + card.data.brokenPower;
        for (int i = 0; i < maxPower; i++)
        {
            Vector3 pos = transform.position;
            pos.x += (maxPower * -10f * card.transform.lossyScale.x) + (i + 0.5f) * 20f * card.transform.lossyScale.x;

            if (i < card.data.emptyPower) Instantiate(emptyPowerIcon, pos, Quaternion.identity, transform);
            else if (i < card.data.emptyPower + card.data.normalPower) Instantiate(normalPowerIcon, pos, Quaternion.identity, transform);
            else Instantiate(brokenPowerIcon, pos, Quaternion.identity, transform);
        }
    }

    private void Update()
    {
    }
}