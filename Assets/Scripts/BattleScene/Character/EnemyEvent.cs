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
        OnTurnStart += TurnStartShieldClear;
        OnCharacterDied += OnEnemyDied;
    }

    private void OnDestroy()
    {
        BattleStateManager.Instance.OnEnemyTurnStart -= OnEnemyTurnStart;
        BattleStateManager.Instance.OnEnemyTurnEnd -= OnEnemyTurnEnd;
        OnTurnStart -= TurnStartShieldClear;
        OnCharacterDied -= OnEnemyDied;
    }

    private void OnEnemyDied(object sender, EventArgs e)
    {
        BattleStateManager.Instance.SetBattleEnd(true);
    }

    private void TurnStartShieldClear(object sender, EventArgs e)
    {
        character.SetShield(0);
    }

    public override void StatusSetUp()
    {
        character.SetHealthPointMax(GetComponent<EnemyDisplay>().enemy.GetHealth(MapData.Instance.playerLocation.y));
        character.SetHealthPoint(GetComponent<EnemyDisplay>().enemy.GetHealth(MapData.Instance.playerLocation.y));
        character.SetShield(0);
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

}