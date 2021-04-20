using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition 
{
    public Character character;



    public virtual void Add(int value)
    {
        return;
    }


    public virtual void Excute()
    {
        return;
    }



    private void OnDestroy()
    {
        character.conditions.Remove(this);
    }

}
