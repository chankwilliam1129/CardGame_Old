using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEventManager : MonoBehaviour
{
    public List<BattleEvent> eventList;

    private bool isExecute;

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
        if (isExecute) return true;
        else if (eventList.Count == 0) return false;
        else
        {
            eventList[0].gameObject.SetActive(true);
        }
        return true;
    }

}