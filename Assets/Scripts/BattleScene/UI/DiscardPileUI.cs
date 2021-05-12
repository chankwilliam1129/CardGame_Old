using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiscardPileUI : MonoBehaviour
{
    public TextMeshProUGUI total;
    public static DiscardPileUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

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