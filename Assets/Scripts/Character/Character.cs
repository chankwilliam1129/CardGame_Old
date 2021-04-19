using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageData
{
    public DamageData(int d, Character c)
    {
        damage = d;
        from = c;
    }

    public int damage;
    public Character from;
}

public class Character : MonoBehaviour
{
    public int healthPoint;
    public int healthPointMax;

    public event EventHandler OnHealthChanged;

    public event EventHandler OnCharacterDied;

    public event EventHandler<DamageData> OnGetDamaged;

    private void Start()
    {
        OnGetDamaged += Character_OnGetDamaged;
    }

    private void Character_OnGetDamaged(object sender, DamageData e)
    {
        healthPoint -= e.damage;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            GetDamage(1, null);
        }

        if (healthPoint <= 0)
        {
            OnCharacterDied?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }

    public void SetHealthPointMax(int hp)
    {
        healthPointMax = hp;
        healthPoint = hp;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public void GetDamage(int damage, Character from)
    {
        DamageData damageData = new DamageData(damage, from);
        OnGetDamaged?.Invoke(this, damageData);
    }
}