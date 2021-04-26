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
        MAX,
    }

<<<<<<< Updated upstream
=======
    public List<AnimationMovement>[] AnimationMovementList = new List<AnimationMovement>[BattleSceneState.MAX.GetHashCode()];

>>>>>>> Stashed changes
    public event EventHandler OnBattleStart;

    public event EventHandler OnPlayerTurnStart;

    public event EventHandler OnPlayerTurnEnd;

    public event EventHandler OnEnemyTurnStart;

    public event EventHandler OnEnemyTurnEnd;

    public BattleSceneState nowState;

    public Transform mainGameCanvas;

    [Space]
    public BattleEvent playerTurnStartText;

    public static BattleStateManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for(int i = 0;i < BattleSceneState.MAX.GetHashCode();i++)
        {
            AnimationMovementList[i] = new List<AnimationMovement>();
        }
        nowState = BattleSceneState.BATTLE_START;
        OnPlayerTurnStart += BattleStateManager_OnPlayerTurnStart;
    }

    private void BattleStateManager_OnPlayerTurnStart(object sender, EventArgs e)
    {
        Instantiate(playerTurnStartText, mainGameCanvas);
    }

    private void Update()
    {
        switch (nowState)
        {
            case BattleSceneState.BATTLE_START:
                OnBattleStart?.Invoke(this, EventArgs.Empty);
<<<<<<< Updated upstream
                nowState = BattleSceneState.PLAYER_TURN_START;
                OnPlayerTurnStart?.Invoke(this, EventArgs.Empty);
                break;

            case BattleSceneState.PLAYER_TURN_START:
                if (!BattleEventManager.Instance.Execute())
=======
                if (AnimationMovementList[nowState.GetHashCode()].Count == 0)
                {
                    nowState = BattleSceneState.PLAYER_TURN_START;
                }
                break;

            case BattleSceneState.PLAYER_TURN_START:
                OnPlayerTurnStart?.Invoke(this, EventArgs.Empty);
                if (AnimationMovementList[nowState.GetHashCode()].Count == 0)
>>>>>>> Stashed changes
                {
                    nowState = BattleSceneState.PLAYER_TURN_UPDATE;
                }
                break;

            case BattleSceneState.PLAYER_TURN_UPDATE:
                break;

            case BattleSceneState.PLAYER_TURN_END:
<<<<<<< Updated upstream
                if (!BattleEventManager.Instance.Execute())
                {
                    nowState = BattleSceneState.ENEMY_TURN_START;
                    OnEnemyTurnStart?.Invoke(this, EventArgs.Empty);
=======
                OnPlayerTurnEnd?.Invoke(this, EventArgs.Empty);
                if (AnimationMovementList[nowState.GetHashCode()].Count == 0)
                {
                    nowState = BattleSceneState.ENEMY_TURN_START;
>>>>>>> Stashed changes
                }
                break;

            case BattleSceneState.ENEMY_TURN_START:
<<<<<<< Updated upstream
                if (!BattleEventManager.Instance.Execute())
=======
                OnEnemyTurnStart?.Invoke(this, EventArgs.Empty);
                if (AnimationMovementList[nowState.GetHashCode()].Count == 0)
>>>>>>> Stashed changes
                {
                    nowState = BattleSceneState.ENEMY_TURN_UPDATE;
                }
                break;

            case BattleSceneState.ENEMY_TURN_UPDATE:
<<<<<<< Updated upstream
                if (!BattleEventManager.Instance.Execute())
                {
                    nowState = BattleSceneState.ENEMY_TURN_END;
                    OnEnemyTurnEnd?.Invoke(this, EventArgs.Empty);
=======
                if (AnimationMovementList[nowState.GetHashCode()].Count == 0)
                {
                    nowState = BattleSceneState.ENEMY_TURN_END;
>>>>>>> Stashed changes
                }
                break;

            case BattleSceneState.ENEMY_TURN_END:
<<<<<<< Updated upstream
                if (!BattleEventManager.Instance.Execute())
                {
                    nowState = BattleSceneState.PLAYER_TURN_START;
                    OnPlayerTurnStart?.Invoke(this, EventArgs.Empty);
=======
                OnEnemyTurnEnd?.Invoke(this, EventArgs.Empty);
                if (AnimationMovementList[nowState.GetHashCode()].Count == 0)
                {
                    nowState = BattleSceneState.PLAYER_TURN_START;
>>>>>>> Stashed changes
                }
                break;

            case BattleSceneState.BATTLE_END:
                break;
        }
    }

    public bool IsPlayerTurn()
    {
        return nowState == BattleSceneState.PLAYER_TURN_UPDATE;
    }

    public void PlayerTurnEnd()
    {
        if (!BattleEventManager.Instance.Execute()) nowState = BattleSceneState.PLAYER_TURN_END;
        OnPlayerTurnEnd?.Invoke(this, EventArgs.Empty);
    }
}