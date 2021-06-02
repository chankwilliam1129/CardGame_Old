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

    [Header("ScrollBar")]
    public float ScrollBarValue;

    public Vector2 ScrollBarPivot;

    [Space]
    public List<List<NodeSaveData>> saveNodeMap = new List<List<NodeSaveData>>();

    public List<Vector2Int> selectedNode = new List<Vector2Int>();

    public static MapData Instance { get; private set; }

    private void OnEnable()
    {
        Instance = this;
    }

    public void StartNewGame()
    {
        playerLocation = new Vector2Int(0, 0);
        ScrollBarValue = 0;
        ScrollBarPivot = new Vector2(0, 1);
        saveNodeMap.Clear();
        selectedNode.Clear();
        selectedNode.Add(Vector2Int.zero);
    }

    public Node GetPlayerNode()
    {
        return MapManager.Instance.nodeMap[playerLocation.y][playerLocation.x];
    }
}