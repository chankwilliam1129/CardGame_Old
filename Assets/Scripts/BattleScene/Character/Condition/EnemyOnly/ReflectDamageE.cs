using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectDamageE : Condition
{
    public int damage;

    private void Start()
    {
        character.conditionList.Add(this);
        //character.characterEvent.OnTurnEnd += OnTurnStart;
        EnemyArea.Instance.enemy.characterEvent.OnTurnStart += OnTurnStart;
        character.characterEvent.OnGetDamaged += OnGetDamaged;
    }

    private void OnGetDamaged(object sender, System.EventArgs e)
    {
        DamageEventArgs args = e as DamageEventArgs;
        if (args.damage >= damage)
        {
            //reflectdmg = args.damage;
            //args.damage -= 3;
            PlayerArea.Instance.player.ChangeHealthPoint(-args.damage);
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
        EnemyArea.Instance.enemy.characterEvent.OnTurnStart -= OnTurnStart;
        character.characterEvent.OnGetDamaged -= OnGetDamaged;
    }

    public override Condition Exist(Character character)
    {
        Condition condition = null;
        foreach (var con in character.conditionList)
        {
            condition = con.GetComponent<ReflectDamageE>();
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
