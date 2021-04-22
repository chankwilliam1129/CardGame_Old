using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class CharacterEvent : MonoBehaviour
{
    public struct DamageData
    {
        public DamageData(int d, Character c)
        {
            damage = d;
            from = c;
        }

        public int damage;
        public Character from;
    }

    public Character character;

    public event EventHandler OnTurnStart;

    public event EventHandler OnTurnEnd;

    public event EventHandler OnCharacterDied;

    public event EventHandler<DamageData> OnGetDamaged;

    public event EventHandler<int> OnGetHeal;

    public event EventHandler<int> OnGetHealEnergy;

    public event EventHandler<int> OnGetSelfDamage;

    public void Start()
    {
        character = GetComponent<Character>();
    }

    public void Update()
    {
        if (!character.IsAlive())
        {
            OnCharacterDied?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);

            SceneManager.LoadScene("AdventureScene");

        }
    }

    public void GetDamage(int damage, Character from)
    {
        DamageData damageData = new DamageData(damage, from);
        OnGetDamaged?.Invoke(this, damageData);
        character.LoseHealthPoint(damage);
    }

    public void GetHeal(int heal)
    {
        OnGetHeal?.Invoke(this, heal);
        character.HealHealthPoint(heal);
    }

    public void GetHealEnergy(int heal)
    {
        OnGetHealEnergy?.Invoke(this, heal);
        character.HealEnergyPoint(heal);
    }

    public void GetSelfDamage(int damage)
    {
        OnGetSelfDamage?.Invoke(this, damage);
        character.LoseHealthPoint(damage);
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