using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Node node;
    public Transform mapParent;
    public int mapSize;

    public NodeData[] nodeDatas = new NodeData[(int)NodeType.Max];
    public List<List<Node>> nodeMap = new List<List<Node>>();

    public static MapManager Instance { get; private set; }

    private MapManager()
    {
        Instance = this;
    }
    private void Start()
    {
        CreateMap(NodeType.EliteEnemy, 1);
        for (int i = 0; i < mapSize; i++)
        {
            if (i == 3) CreateMap(NodeType.Store, 5);
            else CreateMap(NodeType.MinorEnemy, 5);
        }
    }
    public Node CreateNode(NodeType nodeType, Vector2Int location)
    {
        return Instantiate(node, mapParent).SetNodeData(nodeDatas[(int)nodeType], location);
    }
    public List<Node> CreateNodeList()
    {
        List<Node> nodeList = new List<Node>();
        return nodeList;
    }
    private void CreateMap(NodeType nodeType, int value)
    {
        List<Node> nodeList = CreateNodeList();
        for (int v = 0; v < value; v++)
        {
            nodeList.Add(CreateNode(nodeType, new Vector2Int(nodeList.Count, nodeMap.Count)));
        }
        nodeMap.Add(nodeList);
    }
    public List<Node> GetNodeList(int y)
    {
        if (y < 0) { y = 0; }
        return nodeMap[y];
    }
}
