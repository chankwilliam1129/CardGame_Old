using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardGenerate : MonoBehaviour
{
    [SerializeField] public List<CardBattleData.Effect> effects;

    public abstract string GetDescription(Vector2Int value, bool isFinal);

    public abstract CardGenerate SetUp(CardDisplay cardDisplay);
}