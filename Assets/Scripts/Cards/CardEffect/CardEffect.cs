using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffect : ScriptableObject
{
    public CardEffectExecutor.AffectType type;

    public abstract string GetDescription(Vector2Int value);

    public virtual void PreExecute(Vector2Int value)
    {
        return;
    }

    public virtual void Execute(Vector2Int value, int power)
    {
        return;
    }

    protected Vector2Int GetValue(Vector2Int value)
    {
        if (CardEffectExecutor.Instance != null)
        {
            Vector2 temp = value;
            temp += CardEffectExecutor.Instance.GetValueAdd(type) + CardEffectExecutor.Instance.GetValueAdd(CardEffectExecutor.AffectType.All);
            Vector2 multi = CardEffectExecutor.Instance.GetValueMulti(type) + CardEffectExecutor.Instance.GetValueMulti(CardEffectExecutor.AffectType.All);
            temp.x *= 1.0f + multi.x;
            temp.y *= 1.0f + multi.y;

            if (value.y == 0)
            {
                return new Vector2Int((int)temp.x, 0);
            }
            else
            {
                return new Vector2Int((int)temp.x, (int)temp.y);
            }
        }
        else
        {
            return value;
        }
    }

    protected int GetFinalValue(Vector2Int value, int power)
    {
        Vector2Int temp = GetValue(value);
        return temp.x + temp.y * power;
    }

    protected string GetValueString(Vector2Int v)
    {
        string valueString = "";
        Vector2Int value = GetValue(v);

        if (value.x > v.x) valueString += "<#00FF00>";
        else if (value.x < v.x) valueString += "<#FF0000>";
        valueString += value.x.ToString();
        if (value.x != v.x) valueString += "</color>";
        if (value.y == 0) return valueString;
        valueString += "(";
        if (value.y > v.y) valueString += "<#00FF00>";
        else if (value.y < v.y) valueString += "<#FF0000>";
        valueString += value.y.ToString();
        if (value.y != v.y) valueString += "</color>";
        valueString += ")";
        return valueString;
    }
}