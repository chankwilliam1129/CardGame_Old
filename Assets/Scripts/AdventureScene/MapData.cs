using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MapData : ScriptableObject
{
    public Vector2Int playerLocation;

    public static MapData Instance { get; private set; }

    private void OnEnable()
    {
        Instance = this;
        playerLocation = new Vector2Int(0, 0);
    }
}
