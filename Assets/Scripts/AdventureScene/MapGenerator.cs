using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public NodeDataManager nodeDataManager;
    public Map map;
    public Map GetMap()
    {
        map.SetWidthNodes(nodeDataManager.SetNodeData(NodeType.MinorEnemy));
        map.SetWidthNodes(nodeDataManager.SetNodeData(NodeType.EliteEnemy));
        map.SetHeightNodes(map.widthNodesList);
        map.SetNodes();
        Instantiate(map);
        return map;
    }
}
