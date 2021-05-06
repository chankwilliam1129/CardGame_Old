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

    public void DescriptionUpdate(bool isFinal)
    {
        string text = "";

        foreach (var effect in cardDisplay.data.effects)
        {
            text += effect.type.GetDescription(effect.value, isFinal);
            text += "\n";
        }

        GetComponent<TextMeshProUGUI>().text = text;
    }

    private void Update()
    {
    }
}