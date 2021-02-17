using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int healthPoint;
    public int healthPointMax;

    public event EventHandler OnHealthChanged;
    public event EventHandler OnCharacterDied;

    public virtual int GetHealthPointMax() { return 10; }

    void Start()
    {
        healthPointMax = GetHealthPointMax();
        healthPoint = healthPointMax;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            healthPoint--;
            OnHealthChanged?.Invoke(this, EventArgs.Empty);
        }

        if(healthPoint<=0)
        {
            OnCharacterDied?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}
