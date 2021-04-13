using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public CardBattleData data;

    [Space]
    public TextMeshProUGUI nameText;

    public Image cardImage;

    private void Start()
    {
        nameText.text = data.preset.name;
        cardImage.sprite = data.preset.image;
    }

    private void Update()
    {
    }

    public void OnInputSlot()
    {
        GetComponent<Animator>().SetBool("isSlot", true);
    }
}