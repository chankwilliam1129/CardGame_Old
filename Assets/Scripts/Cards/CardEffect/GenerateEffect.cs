using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/GenerateEffect", fileName = "GenerateEffect")]
public class GenerateEffect : CardEffect
{
    public CardGenerate generate;

    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return generate.GetDescription(value, isFinal);
    }

    public override void Generate(Vector2Int value, GameObject cardDisplay)
    {
        generate.SetUp(cardDisplay.GetComponent<CardDisplay>());
    }
}