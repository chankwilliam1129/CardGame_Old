using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectBurning : Condition
{
    public int damage;
    public Burning burning;
    public int burning_stack;

    private void Start()
    {
        character.conditionList.Add(this);
        //character.characterEvent.OnTurnEnd += OnTurnStart;
        PlayerArea.Instance.player.characterEvent.OnTurnStart += OnTurnStart;
        character.characterEvent.OnGetDamage += OnGetDamage;

    }

    private void OnGetDamage(object sender, System.EventArgs e)
    {
        DamageEventArgs args = e as DamageEventArgs;
        if (args.from != null && args.damage >= damage)
        {
            Condition con = burning.Exist(args.from);
            if (con == null)
            {
                con = Instantiate(burning, args.from.conditionDisplay);
                con.character = args.from;
            }
            con.Add(burning_stack);
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
        stack -= 1;
    }

    public override void DestoryEvent()
    {
        PlayerArea.Instance.player.characterEvent.OnTurnStart -= OnTurnStart;
        character.characterEvent.OnGetDamage -= OnGetDamage;

    }

    public override Condition Exist(Character character)
    {
        Condition condition = null;
        foreach (var con in character.conditionList)
        {
            condition = con.GetComponent<ReflectBurning>();
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
