using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddConditionEvent : MonoBehaviour
{
    public Condition condition;
    public Character target;
    public int value;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        if (target != null)
        {
            Condition con = condition.Exist(target);
            if (con == null)
            {
                con = Instantiate(condition, target.conditionDisplay);
                con.character = target;
            }
            con.Add(value);
        }
    }
}