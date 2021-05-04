using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCardOnTurnEnd : MonoBehaviour
{
    private CardDisplay cardDisplay;

    private void Start()
    {
        cardDisplay = GetComponentInParent<CardDisplay>();
        PlayerArea.Instance.player.characterEvent.OnTurnEnd += TurnEnd;
    }

    private void TurnEnd(object sender, System.EventArgs e)
    {
        BattleDeckManager.Instance.Remove(cardDisplay);
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        PlayerArea.Instance.player.characterEvent.OnTurnEnd -= TurnEnd;
    }
}