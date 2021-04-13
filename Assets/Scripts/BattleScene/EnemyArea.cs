using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    public CardSlot cardSlot;
    public Character nowSelectEnemy;

    public static EnemyArea Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}