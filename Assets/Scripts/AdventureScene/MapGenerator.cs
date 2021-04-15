using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public NodeDataManager nodeDataManager;
    public Map map;
    public Map GetMap()
    {
        int widthNodes = Random.Range(3, 5);
        int w;
        for (w = 0; w <= widthNodes; w++) 
        {
            if (w % 2 == 0) 
            {
                map.SetWidthNodes(nodeDataManager.SetNodeData(NodeType.MinorEnemy));
            }
            else map.SetWidthNodes(nodeDataManager.SetNodeData(NodeType.EliteEnemy));
        }
        //map.SetWidthNodes(nodeDataManager.SetNodeData(NodeType.MinorEnemy));
       // map.SetWidthNodes(nodeDataManager.SetNodeData(NodeType.EliteEnemy));
        map.SetHeightNodes(map.widthNodesList);
        map.SetNodes();
        Instantiate(map);
        return map;
    }
}
