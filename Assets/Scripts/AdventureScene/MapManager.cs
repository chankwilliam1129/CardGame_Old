using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Node node;
    public Transform mapParent;

    public NodeData[] nodeDatas = new NodeData[(int)NodeType.Max];

    public List<List<Node>> nodeMap = new List<List<Node>>();

    private int mapSize = 5;
    private void Start()
    {        
        for (int i = 0; i < mapSize; i++)
        {
            CreateMap(NodeType.EliteEnemy, 5);
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
    //public void PassNodes()
    //{
    //    GetComponent<Animator>().SetBool("isPass", true);
    //}
}
