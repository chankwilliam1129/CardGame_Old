using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition : MonoBehaviour
{
    public Character character;
    public string conditionName;

    public abstract Condition Exist(Character character);

    public abstract void Add(int value);

    public abstract void DestoryEvent();

    private void OnDestroy()
    {
        DestoryEvent();
        character.conditionList.Remove(this);
    }
}