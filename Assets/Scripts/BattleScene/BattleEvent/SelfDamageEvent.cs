using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDamageEvent : MonoBehaviour
{
    public int damage;
    public Character target;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        target.characterEvent.GetDamage(damage, target);
    }
}