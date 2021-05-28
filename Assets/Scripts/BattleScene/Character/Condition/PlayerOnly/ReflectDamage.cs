using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectDamage : Condition
{
    public int damage;
    private int reflectdmg;
    private void Start()
    {
        character.conditionList.Add(this);
        //character.characterEvent.OnTurnEnd += OnTurnStart;
        PlayerArea.Instance.player.characterEvent.OnTurnStart += OnTurnStart;
        character.characterEvent.OnGetDamaged += OnGetDamaged;
        character.characterEvent.OnBlockDamage += OnBlockDamage;
    }

    private void OnGetDamaged(object sender, System.EventArgs e)
    {
        DamageEventArgs args = e as DamageEventArgs;
        if (args.damage >= damage)
        {
            EnemyArea.Instance.enemy.ChangeHealthPoint(-args.damage);
        }
    }

    private void OnBlockDamage(object sender, System.EventArgs e)
    {
        DamageEventArgs args = e as DamageEventArgs;
        if (character.GetShield() != 0)
        {
            EnemyArea.Instance.enemy.ChangeHealthPoint(-args.damage);
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
        character.characterEvent.OnGetDamaged -= OnGetDamaged;
        character.characterEvent.OnBlockDamage -= OnBlockDamage;
    }

    public override Condition Exist(Character character)
    {
        Condition condition = null;
        foreach (var con in character.conditionList)
        {
            condition = con.GetComponent<ReflectDamage>();
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
