using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterEvent : MonoBehaviour
{
    public Character character;

    public event EventHandler OnTurnStart;

    public event EventHandler OnTurnEnd;

    public event EventHandler OnCharacterDied;

    public event EventHandler<DamageData> OnGetDamaged;

    public event EventHandler<HealData> OnGetHeal;

    private void CharacterEvent_OnGetDamaged(object sender, DamageData e)
    {
        character.LoseHealthPoint(e.damage);
    }

    public void Start()
    {
        character = GetComponent<Character>();
        OnGetDamaged += CharacterEvent_OnGetDamaged;
    }

    public void Update()
    {
        if (!character.IsAlive())
        {
            OnCharacterDied?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }

    public void GetDamage(int damage, Character from)
    {
        DamageData damageData = new DamageData(damage, from);
        OnGetDamaged?.Invoke(this, damageData);
    }

    public void GetHeal(int heal, Character from)
    {
        HealData healData = new HealData(heal, from);
        OnGetHeal?.Invoke(this, healData);
    }

    public void OnTurnStartEvent()
    {
        OnTurnStart?.Invoke(this, EventArgs.Empty);
    }

    public void OnTurnEndEvent()
    {
        OnTurnEnd?.Invoke(this, EventArgs.Empty);
    }
}