using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MapData : ScriptableObject
{
    public Vector2Int playerLocation;

    public List<List<NodeType>> saveNodeMap = new List<List<NodeType>>();
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
