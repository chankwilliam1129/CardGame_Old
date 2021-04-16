using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Node node;
    public Transform canvas;

    public NodeData[] nodeDatas = new NodeData[(int)NodeType.Max];

    public List<List<Node>> nodeMap = new List<List<Node>>();

    private void Start()
    {
        List<Node> nodeList = CreateNodeList();
        nodeList.Add(CreateNode(NodeType.EliteEnemy, new Vector2(0, 0)));
        nodeList.Add(CreateNode(NodeType.EliteEnemy, new Vector2(500, 0)));
        nodeMap.Add(nodeList);
    }

    public Node CreateNode(NodeType nodeType, Vector2 pos)
    {
        Vector3 cp = canvas.position;
        cp.x += pos.x;
        cp.y += pos.y;
        return Instantiate(node, cp, Quaternion.identity,canvas).SetNodeData(nodeDatas[(int)nodeType]); 
    }

    public List<Node> CreateNodeList()
    {
        List<Node> nodeList = new List<Node>();
        return nodeList;
    }
}
