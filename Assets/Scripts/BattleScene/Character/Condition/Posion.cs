using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posion : Condition
{
    public int stack;

    private void Start()
    {
        character.conditionList.Add(this);
        character.characterEvent.OnTurnEnd += OnTurnEnd;
    }

    private void OnTurnEnd(object sender, System.EventArgs e)
    {
        character.LoseHealthPoint(stack);
        stack /= 2;

        if (stack <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
    }

    public override void DestoryEvent()
    {
        character.characterEvent.OnTurnEnd -= OnTurnEnd;
    }

    public override Condition Exist(Character character)
    {
        Condition condition = null;
        foreach (var con in character.conditionList)
        {
            condition = con.GetComponent<Posion>();
            if (condition != null) break;
        }
        return condition;
    }

    public override void Add(int value)
    {
        stack += value;
    }
}