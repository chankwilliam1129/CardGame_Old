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

public class HealData
{
    public HealData(int d, Character c)
    {
        heal = d;
        from = c;
    }

    public int heal;
    public Character from;
}

public class Character : MonoBehaviour
{
    public CharacterEvent characterEvent;
    private int healthPoint;
    private int healthPointMax;

    public List<Condition> conditionList;

    public event EventHandler OnHealthChanged;

    private void Start()
    {
        characterEvent = GetComponent<CharacterEvent>();
    }

    private void Update()
    {
    }

    public void SetHealthPointMax(int hp)
    {
        healthPointMax = hp;
        healthPoint = hp;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SetHealthPoint(int hp)
    {
        healthPoint = hp;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public void LoseHealthPoint(int hp)
    {
        healthPoint -= hp;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }
    public void HealHealthPoint(int hp)
    {
        if(GetHealthPointMax() > healthPoint)
        healthPoint += hp;

        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetHealthPoint()
    {
        return healthPoint;
    }

    public int GetHealthPointMax()
    {
        return healthPointMax;
    }

    public bool IsAlive()
    {
        return healthPoint > 0;
    }
}