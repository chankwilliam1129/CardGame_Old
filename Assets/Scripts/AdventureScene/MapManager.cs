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
        int nodeValue = Random.Range(3, 6);
        for (int v = 0; v < nodeValue; v++)
        {
            nodeList.Add(CreateNode(NodeType.EliteEnemy, new Vector2(nodeList.Count * 100, nodeMap.Count * 100)));
        }
        nodeMap.Add(nodeList);

        List<Node> nodeList2 = CreateNodeList();
        int nodeValue2 = Random.Range(3, 6);
        for (int v = 0; v < nodeValue2; v++)
        {
            nodeList2.Add(CreateNode(NodeType.MinorEnemy, new Vector2(nodeList2.Count * 100, nodeMap.Count * 100)));
        }
        nodeMap.Add(nodeList2);
    }

    public Node CreateNode(NodeType nodeType, Vector2 pos)
    {
        Vector3 cp = canvas.position;
        cp.x += pos.x;
        cp.y += pos.y;
        return Instantiate(node, cp, Quaternion.identity, canvas).SetNodeData(nodeDatas[(int)nodeType]);
    }
    
    public List<Node> CreateNodeList()
    {
        List<Node> nodeList = new List<Node>();
        return nodeList;
    }
}
