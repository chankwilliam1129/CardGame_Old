using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDown : Condition
{
    private void Start()
    {
        character.conditionList.Add(this);
        character.characterEvent.OnTurnEnd += OnTurnEnd;
    }

    private void OnTurnEnd(object sender, System.EventArgs e)
    {
        stack--;
        text.text = stack.ToString();
        if (stack <= 0) Destroy(gameObject);
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
            condition = con.GetComponent<PowerDown>();
            if (condition != null) break;
        }
        return condition;
    }

    public override void Add(int value)
    {
        stack += value;
        text.text = stack.ToString();
    }
}
