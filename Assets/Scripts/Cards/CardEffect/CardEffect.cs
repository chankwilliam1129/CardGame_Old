using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffect : ScriptableObject
{
    public abstract string GetDescription(Vector2Int value);

    public virtual void PreExecute(Vector2Int value)
    {
        return;
    }

    public virtual void Execute(Vector2Int value, int power)
    {
        return;
    }
}