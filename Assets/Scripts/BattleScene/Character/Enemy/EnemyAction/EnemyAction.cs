using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAction : ScriptableObject
{
    public Sprite sprite;

    public abstract string GetDescription(int value);

    public virtual void Execute(int value)
    {
        return;
    }

}