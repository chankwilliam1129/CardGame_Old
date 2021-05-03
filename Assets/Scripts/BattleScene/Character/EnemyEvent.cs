using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvent : CharacterEvent
{
    public new void Start()
    {
        base.Start();
        BattleStateManager.Instance.OnEnemyTurnStart += OnEnemyTurnStart;
        BattleStateManager.Instance.OnEnemyTurnEnd += OnEnemyTurnEnd;
    }

    private void OnEnemyTurnStart(object sender, System.EventArgs e)
    {
        TurnStart();
    }

    private void OnEnemyTurnEnd(object sender, System.EventArgs e)
    {
        TurnEnd();
    }

    public new void Update()
    {
        base.Update();
    }

    private void OnDestroy()
    {
        BattleStateManager.Instance.OnEnemyTurnStart -= OnEnemyTurnStart;
        BattleStateManager.Instance.OnEnemyTurnEnd -= OnEnemyTurnEnd;
    }
}