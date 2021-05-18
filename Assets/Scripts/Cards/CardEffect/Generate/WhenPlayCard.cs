using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenPlayCard  : MonoBehaviour
{
    public Card card;
    [SerializeField] public List<CardBattleData.Effect> effects;

    private void Start()
    {
        if (CardEffectExecutor.Instance != null)
        {
            CardEffectExecutor.Instance.OnPlayCard += PlayCard;
        }
    }

    private void OnDestroy()
    {
        if (CardEffectExecutor.Instance != null)
        {
            CardEffectExecutor.Instance.OnPlayCard -= PlayCard;
        }
    }

    private void PlayCard(object sender, System.EventArgs e)
    {
        CardEventArgs cardEventArgs = e as CardEventArgs;
        if (card == null || cardEventArgs.card.data.preset == card)
        {
            foreach (var effect in effects)
            {
                effect.type.Execute(effect.value, 0, GetComponent<CardDisplay>());
            }
        }
    }
}
