using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEnergyEvent : MonoBehaviour
{
    public int heal;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnDestroy()
    {
        PlayerArea.Instance.player.GetComponent<PlayerEvent>().HealEnergy(heal);
    }
}