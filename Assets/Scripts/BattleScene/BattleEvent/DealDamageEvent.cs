using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageEvent : MonoBehaviour
{
    public int damage;
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
        target.characterEvent.GetDamage(damage, from);
    }
}