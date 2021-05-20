using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenTurnStart : MonoBehaviour
{

    [SerializeField] public List<CardBattleData.Effect> effects;

    private void Start()
    {
        if (PlayerArea.Instance != null)
        {
            PlayerArea.Instance.player.characterEvent.OnTurnStart += TurnStart;
        }
    }

    private void OnDestroy()
    {
        if (PlayerArea.Instance != null)
        {
            PlayerArea.Instance.player.characterEvent.OnTurnStart -= TurnStart;
        }
    }

    private void TurnStart(object sender, System.EventArgs e)
    {

        foreach (var effect in effects)
        {
            effect.type.Execute(effect.value, 0, GetComponent<CardDisplay>());
        }

    }
}
