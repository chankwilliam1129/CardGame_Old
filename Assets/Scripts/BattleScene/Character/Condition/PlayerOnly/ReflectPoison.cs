using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectPoison : Condition
{
    public int damage;
    public Poison poison;
    public int poison_stack;

    private void Start()
    {
        character.conditionList.Add(this);
        character.characterEvent.OnTurnStart += OnTurnStart;
        character.characterEvent.OnGetDamage += OnGetDamage;
    }

    private void OnGetDamage(object sender, System.EventArgs e)
    {
        DamageEventArgs args = e as DamageEventArgs;
        if (args.from != null && args.damage >= damage)
        {
            Condition con = poison.Exist(args.from);
            if (con == null)
            {
                con = Instantiate(poison, args.from.conditionDisplay);
                con.character = args.from;
            }
            con.Add(poison_stack);
        }
        Settlement();
        text.text = stack.ToString();
        if (stack <= 0) Destroy(gameObject);
    }

    private void OnTurnStart(object sender, System.EventArgs e)
    {
        Settlement();
        text.text = stack.ToString();
        if (stack <= 0) Destroy(gameObject);
    }

    public void Settlement()
    {
        stack -= 1;
    }

    public override void DestoryEvent()
    {
        character.characterEvent.OnTurnStart -= OnTurnStart;
        character.characterEvent.OnGetDamage -= OnGetDamage;
    }

    public override Condition Exist(Character character)
    {
        Condition condition = null;
        foreach (var con in character.conditionList)
        {
            condition = con.GetComponent<ReflectPoison>();
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