using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectExecutor : MonoBehaviour
{
    public List<CardDisplay> nowModCard;

    public static CardEffectExecutor Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Execute()
    {
        foreach (var effect in HandCardDisplay.Instance.nowDraggingCard.data.playEffects)
        {
            effect.type.Execute(effect.value);
        }
        BattleDeckManager.Instance.Discard(HandCardDisplay.Instance.nowDraggingCard, BattleDeckManager.RemoveType.ToDiscardPile);
    }
}