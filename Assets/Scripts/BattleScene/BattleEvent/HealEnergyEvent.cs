using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEnergyEvent : MonoBehaviour
{
    public int heal;
    public Character target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        target.characterEvent.GetHealEnergy(heal);
    }
}
