using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleDeckUI : MonoBehaviour
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
        total.text = BattleDeckManager.Instance.battleDeck.Count.ToString();
    }
}