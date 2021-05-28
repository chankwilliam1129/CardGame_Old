using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Node node;
    public GameObject parent;
    public Transform mapParent;
    public int mapSize;
    public LineRenderer lineRenderer;

    public NodeData[] nodeDatas = new NodeData[(int)NodeType.Max];
    public List<GameObject> parentList = new List<GameObject>();  
    public List<List<Node>> nodeMap = new List<List<Node>>();

    private float nodeWidthSize = 260f;
    private float nodeHeightSize = 200f;
    private float nodeImageSize = 100f;

    public static MapManager Instance { get; private set; }

    private MapManager()
    {
        Instance = this;
    }

    private void Start()
    {
        //MapData.Instance.saveNodeMap.Clear();
        //MapData.Instance.selectedNode.Clear();

        if (MapData.Instance.saveNodeMap.Count == 0)
        {
            CreateMap();
        }
        else
        { 
            LoadMap();
            LoadLineRenderer();
        }
    }

    public Node CreateNode(NodeType nodeType, Vector2Int location, Transform parent)
    {
        if (nodeType== NodeType.Start|| nodeType == NodeType.Boss)
        {
            return Instantiate(node, new Vector3(50, location.y * nodeHeightSize - 600, 0), Quaternion.identity, parent).SetNodeData(nodeDatas[(int)nodeType], location);
        }
        return Instantiate(node, SetNodePosition(location), Quaternion.identity, parent).SetNodeData(nodeDatas[(int)nodeType], location);       
    }

    public List<Node> CreateNodeList()
    {
        List<Node> nodeList = new List<Node>();
        return nodeList;
    }

    private void CreateMap()
    {
        for (int i = 1; i <= mapSize; i++)
        {
            SetMap(i);
        }
        StateCheck();
    }

    public void StateCheck()
    {
        foreach(var l in nodeMap)
        {
            foreach (var n in l)
            {
                n.StateCheck();
            }
        }
    }

    private void SetMap(int level)
    {
        int value;
        if (level == 1 || level == mapSize) value = 1;
        else value = Random.Range(3, 6);

        GameObject p = Instantiate(parent, mapParent);

        List<Node> nodeList = CreateNodeList();
        List<NodeSaveData> nodeSaveList = new List<NodeSaveData>();

        int curListCount = 0;
        for (int v = 0; v < value; v++)
        {
            NodeType nodeType = GetLevelNodeType(level);

            Node newNode = CreateNode(nodeType, new Vector2Int(nodeList.Count, nodeMap.Count), p.transform);
            nodeList.Add(newNode);
            nodeSaveList.Add(new NodeSaveData(nodeType));

            if (nodeMap.Count == 0) continue;
            else
            {
                float range = 30;
                while (true)
                {
                    nodeMap[nodeMap.Count - 1][curListCount].next.Add(v);
                    MapData.Instance.saveNodeMap[nodeMap.Count - 1][curListCount].next.Add(v);

                    LineRenderer line = Instantiate(lineRenderer, nodeMap[nodeMap.Count - 1][curListCount].transform);
                    line.SetPosition(1, Vector3.zero);
                    line.SetPosition(0, newNode.transform.position - nodeMap[nodeMap.Count - 1][curListCount].transform.position);

                    if (curListCount >= nodeMap[nodeMap.Count - 1].Count - 1) break;
                    else
                    {
                        if (v == value - 1 || Random.Range(0, 100) < range)
                        {
                            curListCount++;
                            range *= 0.4f;
                        }
                        else 
                        {
                            if (Random.Range(0, 100) < 34) curListCount++;
                            break;
                        }
                    }
                }
            }
        }

        parentList.Add(p);
        nodeMap.Add(nodeList);
        MapData.Instance.saveNodeMap.Add(nodeSaveList);
    }

    private NodeType GetLevelNodeType(int level)
    {
        if (level == 1) return NodeType.Start;
        else if (level ==2) return NodeType.MinorEnemy;
        else if(level == 4) return NodeType.Treasure;
        else if (level == mapSize) return NodeType.Boss;
        else
        {
            int range = Random.Range(0, 100);

            if (range < 15) return NodeType.Store;
            else if (range < 25) return NodeType.Treasure;
            else if (range < 50) return NodeType.EliteEnemy;
            else if (range < 85) return NodeType.MinorEnemy;
            else return NodeType.Mystery;
        }
    }

    private void LoadMap()
    {   
        foreach (var nodeTypeLists in MapData.Instance.saveNodeMap)
        {      
            GameObject p = Instantiate(parent, mapParent);
            List<Node> nodeList = CreateNodeList();

            foreach (var nodeSaveData in nodeTypeLists)
            {
                Node node = CreateNode(nodeSaveData.type, new Vector2Int(nodeList.Count, nodeMap.Count), p.transform);
                node.next = nodeSaveData.next;
                nodeList.Add(node);
                node.StateCheck();
            }

            parentList.Add(p);
            nodeMap.Add(nodeList);
        }
    }

    private void LoadLineRenderer()
    {
        foreach(var nodeList in nodeMap)
        {
            foreach(var node in nodeList)
            {
                foreach (var next in node.next)
                {
                    LineRenderer line = Instantiate(lineRenderer, node.transform);
                    line.SetPosition(1, Vector3.zero);
                    line.SetPosition(0, nodeMap[node.location.y + 1][next].transform.position - node.transform.position);
                }
            }
        }
    }

    private Vector3 SetNodePosition(Vector2Int location)
    {
        //if (nodeMap[location.y][location.x] == nodeMap[0][0] || nodeMap[location.y][location.x] == nodeMap[mapSize - 1][0]) 
        //{
        //    return new Vector3(50, location.y * nodeHeightSize - 600, 0);
        //}
        Vector3 pos = new Vector3(0, 0, 0);
        float rx = location.x * nodeWidthSize;
        float ry = location.y * nodeHeightSize;
        pos.x = rx - 400;
        pos.y = ry - 600;
        return pos;
    }
}