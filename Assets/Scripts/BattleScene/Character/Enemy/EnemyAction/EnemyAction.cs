using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAction : ScriptableObject
{
    public virtual void Execute(int value)
    {
        return;
    }

    public virtual void Generate(int value, CardDisplay cardDisplay)
    {
        return;
    }

}