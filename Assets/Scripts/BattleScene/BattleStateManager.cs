using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateManager : MonoBehaviour
{
    public enum BattleSceneState
    {
        BATTLE_START,
        PLAYER_TURN_START,
        PLAYER_TURN_UPDATE,
        PLAYER_TURN_END,
        ENEMY_TURN_START,
        ENEMY_TURN_UPDATE,
        ENEMY_TURN_END,
        BATTLE_END,
    }

    public List<Func<bool>> stateActionList;

    public event EventHandler OnBattleStart;
    public event EventHandler OnPlayerTurnStart;
    public event EventHandler OnPlayerTurnEnd;
    public event EventHandler OnEnemyTurnStart;
    public event EventHandler OnEnemyTurnEnd;

    public BattleSceneState nowState;

    void Start()
    {
        nowState = BattleSceneState.BATTLE_START;
    }

    void Update()
    {
        switch(nowState)
        {
            case BattleSceneState.BATTLE_START:
                OnBattleStart?.Invoke(this, EventArgs.Empty);
                nowState = BattleSceneState.PLAYER_TURN_START;
                break;

            case BattleSceneState.PLAYER_TURN_START:
                OnPlayerTurnStart?.Invoke(this, EventArgs.Empty);
                nowState = BattleSceneState.PLAYER_TURN_UPDATE;
                break;

            case BattleSceneState.PLAYER_TURN_UPDATE:
                break;

            case BattleSceneState.PLAYER_TURN_END:
                OnPlayerTurnEnd?.Invoke(this, EventArgs.Empty);
                nowState = BattleSceneState.ENEMY_TURN_START;
                break;

            case BattleSceneState.ENEMY_TURN_START:
                OnEnemyTurnStart?.Invoke(this, EventArgs.Empty);
                nowState = BattleSceneState.ENEMY_TURN_UPDATE;
                break;

            case BattleSceneState.ENEMY_TURN_UPDATE:
                nowState = BattleSceneState.ENEMY_TURN_END;
                break;

            case BattleSceneState.ENEMY_TURN_END:
                OnEnemyTurnEnd?.Invoke(this, EventArgs.Empty);
                nowState = BattleSceneState.PLAYER_TURN_START;
                break;

            case BattleSceneState.BATTLE_END:
                break; 
        }

    }

    bool stateActionEmpty()
    {
        if (stateActionList.Count == 0) return true;
        else
        {
            if (stateActionList[0]()) stateActionList.Remove(stateActionList[0]);
            return false;
        }
    }

    public void PlayerTurnEnd()
    {
        if (nowState == BattleSceneState.PLAYER_TURN_UPDATE) nowState = BattleSceneState.PLAYER_TURN_END;
    }

}
