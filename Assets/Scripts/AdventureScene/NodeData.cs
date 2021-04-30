using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType
{
    MinorEnemy,
    EliteEnemy,
    //Mystery,
    //Treasure,
    Store,
    //Boss,
    Max,
}

[CreateAssetMenu]
public class NodeData : ScriptableObject
{
    public NodeType nodeType;
    public Sprite sprite;
}
