using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSaveData
{
    public NodeType type;
    public List<int> next;
    
    public NodeSaveData(NodeType t)
    {
        type = t;
        next = new List<int>();
    }
}

[CreateAssetMenu]
public class MapData : ScriptableObject
{
    public Vector2Int playerLocation;

    public List<List<NodeSaveData>> saveNodeMap = new List<List<NodeSaveData>>();
    public List<Vector2Int> selectedNode = new List<Vector2Int>();
    public static MapData Instance { get; private set; }

    private void OnEnable()
    {
        Instance = this;
        playerLocation = new Vector2Int(0, 0);
        saveNodeMap.Clear();
        selectedNode.Clear();
    }
}
