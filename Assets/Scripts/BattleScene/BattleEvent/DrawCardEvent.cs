using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardEvent : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    private void OnDestroy()
    {
        BattleDeckManager.Instance.DrawCard(BattleDeckManager.DrawType.FromBattleDeck);
    }
}