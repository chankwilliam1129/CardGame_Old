using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerArea : MonoBehaviour
{
    public Character player;
    public TextMeshProUGUI cardUsageText;

    public int energy;
    public static PlayerArea Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        BattleStateManager.Instance.OnPlayerTurnStart += OnPlayerTurnStart;
    }

    private void OnPlayerTurnStart(object sender, System.EventArgs e)
    {
        energy = 3;
    }

    private void Update()
    {
        cardUsageText.text = "エナジー：" + energy.ToString();
    }
}