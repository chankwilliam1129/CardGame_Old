using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/DrawCard", fileName = "DrawCard")]
public class DrawCard : CardEffect
{
    public GameObject drawCardEvent;

    public override string GetDescription(Vector2Int value)
    {
        if (value.y != 0) return value.x.ToString() + "(" + value.y.ToString() + ")���J�[�h�������B";
        else return value.x.ToString() + "���J�[�h�������B";
    }

    public override void Execute(Vector2Int value, int power)
    {
        int draw = value.x + value.y * power;
        for (int i = 0; i < draw; i++)
        {
            Instantiate(drawCardEvent);
        }
    }
}