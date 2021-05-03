using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Condition : MonoBehaviour
{
    public int stack;
    public TextMeshProUGUI text;

    public Character character;
    public string conditionName;
    public Color color;

    public abstract Condition Exist(Character character);

    public abstract void Add(int value);

    public abstract void DestoryEvent();

    public string GetText()
    {
        return "<#" + ColorUtility.ToHtmlStringRGB(color) + ">" + conditionName + "</color>";
    }

    private void OnDestroy()
    {
        DestoryEvent();
        character.conditionList.Remove(this);
    }
}