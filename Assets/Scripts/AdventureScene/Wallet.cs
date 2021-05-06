using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Wallet : ScriptableObject
{
    public int coin;

    public static Wallet Instance { get; private set; }
    private Wallet()
    {
        Instance = this;
    }
}
