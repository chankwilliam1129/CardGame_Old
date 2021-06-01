using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAction : ScriptableObject
{
    public Sprite sprite;

    public abstract string GetDescription(Vector2Int value, int level);

    public virtual void Execute(Vector2Int value, int level)
    {
        return;
    }

    protected int GetValue(Vector2Int value,int level)
    {
        return value.x + value.y * level;
    }

}