using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector]
    public CharacterEvent characterEvent;

    private int healthPoint;
    private int healthPointMax;
    private int shield;

    public Transform conditionDisplay;
    public List<Condition> conditionList;

    public event EventHandler OnHealthChanged;

    public event EventHandler OnShieldChanged;
    private void Awake()
    {
        characterEvent = GetComponent<CharacterEvent>();
    }

    private void Start()
    {
    }

    private void Update()
    {
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

    public void SetHealthPointMax(int hp)
    {
        healthPointMax = hp;
        healthPoint = Mathf.Max(Mathf.Min(healthPoint, healthPointMax), 0);
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SetHealthPoint(int hp)
    {
        healthPoint = hp;
        healthPoint = Mathf.Max(Mathf.Min(healthPoint, healthPointMax), 0);
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public void ChangeHealthPoint(int hp)
    {
        healthPoint += hp;
        healthPoint = Mathf.Max(Mathf.Min(healthPoint, healthPointMax), 0);
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetShield()
    {
        return shield;
    }

    public void ChangeShield(int value)
    {
        shield += value;
        OnShieldChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SetShield(int value)
    {
        shield = value;
        OnShieldChanged?.Invoke(this, EventArgs.Empty);
    }
}