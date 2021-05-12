using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RemoveCardOnTurnEnd : CardGenerate
{
    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return "ターン終了時に廃棄する。";
    }

    public override void SetUp(CardDisplay cardDisplay)
    {
        cardDisplay.gameObject.AddComponent<RemoveCardOnTurnEnd>();
        cardDisplay.data.removeType = BattleDeckManager.RemoveType.Exhausted;
    }

    private void Start()
    {
        PlayerArea.Instance.player.characterEvent.OnTurnEnd += TurnEnd;
    }

    private void OnDestroy()
    {
        PlayerArea.Instance.player.characterEvent.OnTurnEnd -= TurnEnd;
    }

    private void TurnEnd(object sender, System.EventArgs e)
    {
        BattleDeckManager.Instance.Remove(GetComponent<CardDisplay>());
    }
}