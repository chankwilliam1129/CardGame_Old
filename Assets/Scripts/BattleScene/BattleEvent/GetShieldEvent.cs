using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShieldEvent : MonoBehaviour
{
    public int shield;
    public Character target;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        target.characterEvent.GetShield(shield);
    }
}