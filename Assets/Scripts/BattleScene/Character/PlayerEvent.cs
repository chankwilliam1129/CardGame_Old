using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : CharacterEvent
{
    public event EventHandler OnHealEnergy;

    public new void Start()
    {
        base.Start();

        BattleStateManager.Instance.OnPlayerTurnStart += OnPlayerTurnStart;
        BattleStateManager.Instance.OnPlayerTurnEnd += OnPlayerTurnEnd;
        OnTurnStart += TurnStartShieldClear;
        OnCharacterDied += OnPlayerDied;
    }

    private void OnDestroy()
    {
        BattleStateManager.Instance.OnPlayerTurnStart -= OnPlayerTurnStart;
        BattleStateManager.Instance.OnPlayerTurnEnd -= OnPlayerTurnEnd;
        OnTurnStart -= TurnStartShieldClear;
        OnCharacterDied -= OnPlayerDied;
    }

    private void TurnStartShieldClear(object sender, EventArgs e)
    {
        character.SetShield((int)(character.GetShield() * PlayerData.Instance.shieldClear));
    }

    private void OnPlayerDied(object sender, EventArgs e)
    {
        BattleStateManager.Instance.SetBattleEnd(false);
    }

    public override void StatusSetUp()
    {
        character.SetHealthPointMax(100);
        character.SetHealthPoint(100);
        character.SetShield(0);
    }

    private void OnPlayerTurnStart(object sender, System.EventArgs e)
    {
        TurnStart();
    }

    private void OnPlayerTurnEnd(object sender, System.EventArgs e)
    {
        TurnEnd();
    }

    public new void Update()
    {
        base.Update();
    }

    public void HealEnergy(int value)
    {
        OnHealEnergy?.Invoke(this, new IntEventArgs(value));
        PlayerArea.Instance.energy += value;
    }
}