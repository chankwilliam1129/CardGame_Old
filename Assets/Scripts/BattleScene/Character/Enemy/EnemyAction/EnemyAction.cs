using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAction : ScriptableObject
{

   // public abstract string GetDescription(Vector2Int value);

    public abstract void Execute(int value);
}