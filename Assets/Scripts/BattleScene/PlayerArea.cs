using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerArea : MonoBehaviour
{
    public Character player;
    public TextMeshProUGUI energyText;
    public RelicDisplay relicDisplay;
    public GameObject relicDisplayGroup;

    public int energy;
    public static PlayerArea Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        BattleStateManager.Instance.OnPlayerTurnStart += OnPlayerTurnStart;

        foreach(var relic in PlayerData.Instance.relic)
        {
            Instantiate(relicDisplay, relicDisplayGroup.transform).relicData = relic;
        }
    }

    private void OnPlayerTurnStart(object sender, System.EventArgs e)
    {
        Debug.Log("Add Energy");
        energy = player.GetEnergyPoint();
    }

    private void Update()
    {
        energyText.text = energy.ToString();
    }
}