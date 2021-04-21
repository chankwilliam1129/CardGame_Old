using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : CharacterEvent
{
    public new void Start()
    {
        base.Start();
        BattleStateManager.Instance.OnPlayerTurnStart += OnPlayerTurnStart;
        BattleStateManager.Instance.OnPlayerTurnEnd += OnPlayerTurnEnd;
    }

    private void OnPlayerTurnStart(object sender, System.EventArgs e)
    {
        OnTurnStartEvent();
    }

    private void OnPlayerTurnEnd(object sender, System.EventArgs e)
    {
        OnTurnEndEvent();
    }

    public new void Update()
    {
        base.Update();
    }
}