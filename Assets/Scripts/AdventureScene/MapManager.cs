using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Node node;
    public GameObject parent;
    public Transform mapParent;
    public int mapSize;

    public NodeData[] nodeDatas = new NodeData[(int)NodeType.Max];
    public List<GameObject> parentList = new List<GameObject>();  
    public List<List<Node>> nodeMap = new List<List<Node>>();

    private float nodeWidthSize = 120;
    private float nodeHeightSize = 130;

    public static MapManager Instance { get; private set; }

    private MapManager()
    {
        Instance = this;
    }

    public enum CreateType
    {
        Normal,
        Level1,
        Level2,
    }

    private void Start()
    {      
        if (MapData.Instance.saveNodeMap.Count == 0) 
        {
            CreateMap(NodeType.Start, 1);
            for (int i = 0; i < mapSize; i++)
            {
                if (i == 0) CreateMap(NodeType.MinorEnemy, 5);
                else if (i == mapSize - 1) CreateMap(NodeType.Boss, 1);
                else if (i == 2) RandomCreateMap(CreateType.Level2, 3);
                else if (i == 4) CreateMap(NodeType.Treasure, 3);
                else RandomCreateMap(CreateType.Level1, 5);
            }

            nodeMap[0][0].GetComponent<Animator>().SetBool("isSelect", true);
        }
        else LoadMap();
    }

    public Node CreateNode(NodeType nodeType, Vector2Int location, Transform parent)
    {     
        if (nodeType == NodeType.Start || nodeType == NodeType.Boss)
        {
            return Instantiate(node, new Vector3(2 * nodeWidthSize + 100, location.y * nodeHeightSize - 500, 0), Quaternion.identity, parent).SetNodeData(nodeDatas[(int)nodeType], location);
        }
        else
        {
            return Instantiate(node, new Vector3(location.x * nodeWidthSize + 100, location.y * nodeHeightSize - 500, 0), Quaternion.identity, parent).SetNodeData(nodeDatas[(int)nodeType], location);
        }
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

    private void RandomCreateMap(CreateType createType, int value)
    {
        GameObject p = Instantiate(parent, mapParent);
        NodeType nodeType = NodeType.MinorEnemy;

        List<Node> nodeList = CreateNodeList();
        List<NodeType> nodeTypeList = new List<NodeType>();

        for (int v = 0; v < value; v++)
        {
            if (createType == CreateType.Level1) nodeType = CreateLevel1Node();
            else if (createType == CreateType.Level2) nodeType = CreateLevel2Node();
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
        if (y < 0) y = 0;
        return nodeMap[y];
    }

    private NodeType CreateLevel1Node()
    {
        float r = Random.Range(0, 101);
        if (r <= 15) return NodeType.Store;
        else if (r <= 30) return NodeType.EliteEnemy;
        else if (r <= 50) return NodeType.Mystery;
        else return NodeType.MinorEnemy;       
    }

    private NodeType CreateLevel2Node()
    {
        float r = Random.Range(0, 101);
        if (r <= 15) return NodeType.Store;
        else if (r <= 30) return NodeType.MinorEnemy;
        else if (r <= 50) return NodeType.Mystery;
        else return NodeType.EliteEnemy;
    }
}