using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardEffectDescription : MonoBehaviour
{
    public TextMeshProUGUI descriptionText;

    [Space]
    public CardBattleData.Effect cardEffect;

    public void SetUp(CardBattleData.Effect effect)
    {
        cardEffect = effect;
        descriptionText.text = effect.type.GetDescription(effect.value);
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}