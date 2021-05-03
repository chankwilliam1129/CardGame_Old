using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardCardEvent : MonoBehaviour
{
    public int discardNumber;

    private void Awake()
    {
        if (discardNumber <= 0 | HandCardDisplay.Instance.cardDisplayList.Count == 0 | CardEffectExecutor.Instance == null)
        {
            Destroy(gameObject);
        }
        else
        {
            CardEffectExecutor.Instance.SetDiscardMode(true);
            CardEffectExecutor.Instance.discardCardEvent = this;
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (discardNumber <= 0 | HandCardDisplay.Instance.cardDisplayList.Count == 0 | CardEffectExecutor.Instance == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (CardEffectExecutor.Instance != null)
        {
            CardEffectExecutor.Instance.SetDiscardMode(false);
            CardEffectExecutor.Instance.discardCardEvent = null;
        }
    }
}