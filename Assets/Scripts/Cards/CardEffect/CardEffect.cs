using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : ScriptableObject
{
    public virtual string GetDescription(Vector2Int value)
    {
        return value.x.ToString() + " " + value.y.ToString();
    }

    public virtual void Execute(Vector2Int value)
    {
        return;
    }
}