using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WhenTurnEnd : MonoBehaviour
{
    [SerializeField] public List<CardBattleData.Effect> effects;

    private void Start()
    {
        if (BattleDeckManager.Instance != null)
        {
            PlayerArea.Instance.player.characterEvent.OnTurnEnd += TurnEnd;
        }
    }

    private void OnDestroy()
    {
        if (BattleDeckManager.Instance != null)
        {
            PlayerArea.Instance.player.characterEvent.OnTurnEnd -= TurnEnd;
        }
    }

    private void TurnEnd(object sender, System.EventArgs e)
    {

        foreach (var effect in effects)
        {
            effect.type.Execute(effect.value, 0, GetComponent<CardDisplay>());
        }
        
    }
}