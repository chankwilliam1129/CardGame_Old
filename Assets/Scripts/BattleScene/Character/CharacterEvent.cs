using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageEventArgs : EventArgs
{
    public int damage { get; set; }
    public Character from { get; set; }

    public DamageEventArgs(int _damage, Character _character)
    {
        damage = _damage;
        from = _character;
    }
}

public class IntEventArgs : EventArgs
{
    public int value { get; set; }

    public IntEventArgs(int _v)
    {
        value = _v;
    }
}

public abstract class CharacterEvent : MonoBehaviour
{
    [HideInInspector]
    public Character character;

    public AudioClip damageSound;
    public AudioClip shieldSound;

    public event EventHandler OnTurnStart;

    public event EventHandler OnTurnEnd;

    public event EventHandler OnCharacterDied;

    public event EventHandler OnBlockDamage;

    public event EventHandler OnGetDamage;

    public event EventHandler OnGetDamaged;

    public event EventHandler OnLoseHealth;

    public event EventHandler OnHealHealth;

    public event EventHandler OnGetShield;

    public void Awake()
    {
        character = GetComponent<Character>();
    }

    public void Start()
    {
    }

    public void Update()
    {
    }

    public abstract void StatusSetUp();

    public void GetDamage(int damage, Character from)
    {
        DamageEventArgs damageargs = new DamageEventArgs(damage, from);
        OnGetDamage?.Invoke(this, damageargs);

        if (character.GetShield() != 0)
        {
            int canShield = Mathf.Min(damageargs.damage, character.GetShield());
            DamageEventArgs shieldArgs = new DamageEventArgs(canShield, from);
            OnBlockDamage?.Invoke(this, shieldArgs);
            character.ChangeShield(-shieldArgs.damage);
            damageargs.damage -= shieldArgs.damage;

            if (damageargs.damage <= 0)
            {
                GetComponent<AudioSource>().clip = shieldSound;
                GetComponent<AudioSource>().Play();
            }
        }

        if (damageargs.damage > 0)
        {
            DamageEventArgs args = new DamageEventArgs(damageargs.damage, from);
            OnGetDamaged?.Invoke(this, args);
            if (args.damage > 0) character.ChangeHealthPoint(-args.damage);

            GetComponent<AudioSource>().clip = damageSound;
            GetComponent<AudioSource>().Play();
        }
    }

    public void GetPenDamage(int damage, Character from)
    {
        if (damage > 0)
        {
            DamageEventArgs args = new DamageEventArgs(damage, from);
            OnGetDamaged?.Invoke(this, args);
            if (args.damage > 0) character.ChangeHealthPoint(-args.damage);
        }
    }

    public void LoseHealth(int value)
    {
        IntEventArgs args = new IntEventArgs(value);
        OnLoseHealth?.Invoke(this, args);
        if (args.value > 0) character.ChangeHealthPoint(-args.value);
    }

    public void HealHealth(int value)
    {
        IntEventArgs args = new IntEventArgs(value);
        OnHealHealth?.Invoke(this, args);
        if (args.value > 0) character.ChangeHealthPoint(args.value);
    }

    public void GetShield(int value)
    {
        IntEventArgs args = new IntEventArgs(value);
        OnGetShield?.Invoke(this, args);
        if (args.value > 0) character.ChangeShield(args.value);
    }

    public void CharacterDied()
    {
        OnCharacterDied?.Invoke(this, EventArgs.Empty);
        Debug.Log("charater died");
    }

    public void TurnStart()
    {
        OnTurnStart?.Invoke(this, EventArgs.Empty);
    }

    public void TurnEnd()
    {
        OnTurnEnd?.Invoke(this, EventArgs.Empty);
    }
}