using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenDiscard : MonoBehaviour
{
    [SerializeField] public List<CardBattleData.Effect> effects;


    private void Start()
    {
        if (BattleDeckManager.Instance != null)
        {
            BattleDeckManager.Instance.OnDiscardCard += OnDiscard;
        }
    }
    private void OnDestroy()
    {
        if (BattleDeckManager.Instance != null)
        {
            BattleDeckManager.Instance.OnDiscardCard -= OnDiscard;
        }
    }

    private void OnDiscard(object sender, System.EventArgs e)
    {
        CardEventArgs cardEventArgs = e as CardEventArgs;
        if (cardEventArgs.card == GetComponent<CardDisplay>())
        {
            foreach (var effect in effects)
            {
                effect.type.Execute(effect.value, 0, cardEventArgs.card);
            }
        }
    }


}
