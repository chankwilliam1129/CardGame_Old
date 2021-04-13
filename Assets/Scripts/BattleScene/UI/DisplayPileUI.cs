using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayPileUI : MonoBehaviour
{
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
        total.text = BattleDeckManager.Instance.discardPile.Count.ToString();
    }
}