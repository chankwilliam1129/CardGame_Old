using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardEvent : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        BattleDeckManager.Instance.DrawCard(BattleDeckManager.DrawType.FromBattleDeck);
    }
}
