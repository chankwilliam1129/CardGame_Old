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
            var r = Instantiate(relicDisplay, relicDisplayGroup.transform);
            r.relicData = relic;
            r.relicData.Generate(r);
        }
    }

    private void OnPlayerTurnStart(object sender, System.EventArgs e)
    {
        energy = PlayerData.Instance.energy;
    }

    private void Update()
    {
        energyText.text = energy.ToString();
    }
}