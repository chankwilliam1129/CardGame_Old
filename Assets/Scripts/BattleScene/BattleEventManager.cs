using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleEventManager : MonoBehaviour
{
    public List<BattleEvent> eventList;

    private bool isExecute;
    public Button turnEndButton;

    public static BattleEventManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isExecute = false;
    }

    public void Add(BattleEvent battleEvent)
    {
        eventList.Add(battleEvent);
    }

    public void Remove(BattleEvent battleEvent)
    {
        eventList.Remove(battleEvent);
        isExecute = false;
    }

    public bool Execute()
    {
        turnEndButton.interactable = false;
        if (isExecute) return true;
        else if (eventList.Count == 0)
        {
            if (BattleStateManager.Instance.nowState == BattleStateManager.BattleSceneState.PLAYER_TURN_UPDATE |
                BattleStateManager.Instance.nowState == BattleStateManager.BattleSceneState.PLAYER_TURN_START)
            {
                turnEndButton.interactable = true;
            }
            return false;
        }
        else
        {
            eventList[0].gameObject.SetActive(true);
        }
        return true;
    }
}