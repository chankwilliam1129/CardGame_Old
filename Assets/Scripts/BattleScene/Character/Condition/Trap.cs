using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Condition
{
    private void Start()
    {
        character.conditionList.Add(this);
        character.characterEvent.OnTurnEnd += OnTurnStart;
        character.characterEvent.OnGetDamaged += OnGetDamaged;
    }

    private void OnGetDamaged(object sender, System.EventArgs e)
    {
        DamageEventArgs args = e as DamageEventArgs;
        if (args.damage >= GetDamage)
        {
            character.ChangeHealthPoint(-args.damage);
        }
    }

    private void OnTurnStart(object sender, System.EventArgs e)
    {
        Settlement();
        text.text = stack.ToString();
        if (stack <= 0) Destroy(gameObject);
    }

    public void Settlement()
    {
        stack /= 2;
    }

    public override void DestoryEvent()
    {
        character.characterEvent.OnTurnEnd -= OnTurnStart;
        character.characterEvent.OnGetDamaged -= OnGetDamaged;
    }

    public override Condition Exist(Character character)
    {
        Condition condition = null;
        foreach (var con in character.conditionList)
        {
            condition = con.GetComponent<Bleeding>();
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
