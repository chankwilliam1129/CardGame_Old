using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEventManager : MonoBehaviour
{
    public static BattleEventManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}