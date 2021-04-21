using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealHpEvent : MonoBehaviour
{
    public int heal;
    public Character from;
    public Character target;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        target.characterEvent.GetHeal(heal);
    }
}