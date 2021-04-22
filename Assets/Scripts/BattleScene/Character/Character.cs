using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterEvent characterEvent;
    private int healthPoint;
    private int healthPointMax;

    public Transform conditionDisplay;
    public List<Condition> conditionList;

    public event EventHandler OnHealthChanged;

    private void HealthChangeCheck(object sender, EventArgs e)
    {
        if (healthPoint > healthPointMax) healthPoint = healthPointMax;
        if (healthPoint < 0) healthPoint = 0;
    }

    private void Start()
    {
        characterEvent = GetComponent<CharacterEvent>();
        OnHealthChanged += HealthChangeCheck;
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
        if (GetHealthPointMax() > healthPoint)
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