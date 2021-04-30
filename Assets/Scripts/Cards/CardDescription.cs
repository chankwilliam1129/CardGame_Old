using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDescription : MonoBehaviour
{
    public CardDisplay cardDisplay;

    private void Start()
    {
    }

    public void DescriptionUpdate()
    {
        string text = "";

        foreach (var effect in cardDisplay.data.playEffects)
        {
            text += effect.type.GetDescription(effect.value);
        }

        GetComponent<TextMeshProUGUI>().text = text;
    }

    private void Update()
    {
    }
}