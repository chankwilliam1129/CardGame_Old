using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Node node;
    public GameObject parent;
    public Transform mapParent;
    public LineRenderer line;

    public int mapSize;

    public NodeData[] nodeDatas = new NodeData[(int)NodeType.Max];
    public List<GameObject> parentList = new List<GameObject>();  
    public List<List<Node>> nodeMap = new List<List<Node>>();

    public static MapManager Instance { get; private set; }

    private MapManager()
    {
        Instance = this;
    }

    private void Start()
    {
        if (MapData.Instance.saveNodeMap.Count == 0) 
        {
            CreateMap(NodeType.EliteEnemy, 1);
            for (int i = 0; i < mapSize; i++)
            {
                if (i == 3) CreateMap(NodeType.Store, 5);
                else if (i == 2) CreateMap(NodeType.Store, 2);
                else CreateMap(NodeType.MinorEnemy, 5);
            }

            nodeMap[0][0].GetComponent<Animator>().SetBool("isSelect", true);
            nodeMap[0][0].GetComponent<Animator>().SetBool("isTouch", false);
            nodeMap[0][0].GetComponent<Animator>().SetBool("isPass", false);
        }
        else LoadMap();

        LineRenderer l = Instantiate(line);
        l.SetPosition(0, nodeMap[0][0].transform.position);
        l.SetPosition(1, nodeMap[1][0].transform.position);
    }

    public Node CreateNode(NodeType nodeType, Vector2Int location, Transform parent)
    {
        return Instantiate(node, parent).SetNodeData(nodeDatas[(int)nodeType], location);
    }

    public List<Node> CreateNodeList()
    {
        List<Node> nodeList = new List<Node>();
        return nodeList;
    }

    private void CreateMap(NodeType nodeType, int value)
    {
        GameObject p = Instantiate(parent, mapParent);

        List<Node> nodeList = CreateNodeList();
        List<NodeType> nodeTypeList = new List<NodeType>();

        for (int v = 0; v < value; v++)
        {
            nodeList.Add(CreateNode(nodeType, new Vector2Int(nodeList.Count, nodeMap.Count), p.transform));
            nodeTypeList.Add(nodeType);
        }
        parentList.Add(p);
        nodeMap.Add(nodeList);
        MapData.Instance.saveNodeMap.Add(nodeTypeList);
    }

    private void LoadMap()
    {   
        foreach (var nodeTypeLists in MapData.Instance.saveNodeMap)
        {
            GameObject p = Instantiate(parent, mapParent);
            List<Node> nodeList = CreateNodeList();
            foreach (var nodeType in nodeTypeLists)
            {
                Node node = CreateNode(nodeType, new Vector2Int(nodeList.Count, nodeMap.Count), p.transform);
                nodeList.Add(node);
                node.StateCheck();
            }
            parentList.Add(p);
            nodeMap.Add(nodeList);
        }
    }

    public List<Node> GetNodeList(int y)
    {
        if (y < 0) { y = 0; }
        return nodeMap[y];
    }
}