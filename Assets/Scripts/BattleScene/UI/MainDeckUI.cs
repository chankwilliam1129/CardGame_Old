using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainDeckUI : MonoBehaviour
{
    public MainDeck mainDeck;

    public Image icon1;
    public Image icon2;
    public Image icon3;
    public Image icon4;

    public TextMeshProUGUI total;

    private void Start()
    {
    }

    private void Update()
    {
        UpdateTotalNumber();
    }

    public void UpdateTotalNumber()
    {
        total.text = mainDeck.deck.Count.ToString();
    }
}