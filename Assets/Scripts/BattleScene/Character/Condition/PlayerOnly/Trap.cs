using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Condition
{
    public int damage;
    public Bleeding bleeding;
    public int bleeding_stack;

    private void Start()
    {
        character.conditionList.Add(this);
        character.characterEvent.OnTurnStart += OnTurnStart;
        character.characterEvent.OnGetDamaged += OnGetDamaged;
        character.characterEvent.OnBlockDamage += OnBlockDamage;

    }

    private void OnGetDamaged(object sender, System.EventArgs e)
    {

        DamageEventArgs args = e as DamageEventArgs;
        if (args.from != null && args.damage >= damage)
        {
            EnemyArea.Instance.enemy.ChangeHealthPoint(-stack);

            Condition con = bleeding.Exist(args.from);
            if (con == null)
            {
                con = Instantiate(bleeding, args.from.conditionDisplay);
                con.character = args.from;
            }
            con.Add(bleeding_stack);

            Settlement();
            text.text = stack.ToString();
            if (stack <= 0) Destroy(gameObject);

        }



    }
    
    private void OnBlockDamage(object sender, System.EventArgs e)
    {

        DamageEventArgs args = e as DamageEventArgs;
        if (args.from != null && character.GetShield() != 0)
        {
            EnemyArea.Instance.enemy.ChangeHealthPoint(-stack);

            Condition con = bleeding.Exist(args.from);
            if (con == null)
            {
                con = Instantiate(bleeding, args.from.conditionDisplay);
                con.character = args.from;
            }
            con.Add(bleeding_stack);

            Settlement();
            text.text = stack.ToString();
            if (stack <= 0) Destroy(gameObject);

        }
    }

    private void OnTurnStart(object sender, System.EventArgs e)
    {
        //Settlement();
        //text.text = stack.ToString();
        //if (stack <= 0) Destroy(gameObject);
    }

    public void Settlement()
    {
        stack = 0;
    }

    public override void DestoryEvent()
    {
        character.characterEvent.OnTurnStart -= OnTurnStart;
        character.characterEvent.OnGetDamaged -= OnGetDamaged;
        character.characterEvent.OnBlockDamage -= OnBlockDamage;
    }

    public override Condition Exist(Character character)
    {
        Condition condition = null;
        foreach (var con in character.conditionList)
        {
            condition = con.GetComponent<ReflectBleeding>();
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
