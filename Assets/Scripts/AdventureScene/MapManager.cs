using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public Node node;
    public LineRenderer lineRenderer;

    [Space]
    public Transform mapParent;
    public GameObject parent;

    [Header("ScrollBar")]
    public Scrollbar scrollbar;
    public GameObject content;

    [Space]
    public int mapSize;
    public float nodeWidthSize;
    public float nodeHeightSize;

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
            SetMap();       
        }
        else
        {
            LoadMap();
        }
        LoadLineRenderer();
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

    private void SetMap()
    {
        for (int i = 1; i <= mapSize; i++)
        {
            CreateMap(i);
        }
        SetNodePosition();
        StateCheck();
    }

    private void CreateMap(int level)
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
        SetNodePosition();
        SetScrollBarPosition();
    }

    private void LoadLineRenderer()
    {
        foreach (var nodeList in nodeMap)
        {
            foreach (var node in nodeList)
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

    public void StateCheck()
    {
        foreach (var l in nodeMap)
        {
            foreach (var n in l)
            {
                n.StateCheck();
            }
        }
    }

    private NodeType GetLevelNodeType(int level)
    {
        if (level == 1) return NodeType.Start;
        else if (level == 2) return NodeType.MinorEnemy;
        else if (level == 4) return NodeType.Treasure;
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

    private void SetNodePosition()
    {
        foreach (var l in nodeMap)
        {
            foreach (var n in l)
            {
                n.SetPosition();
            }
        }
    }

    private void SetScrollBarPosition()
    {
        scrollbar.value = MapData.Instance.ScrollBarValue;
        content.GetComponent<RectTransform>().pivot = MapData.Instance.ScrollBarPivot;
    }
}