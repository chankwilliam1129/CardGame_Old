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
        MapData.Instance.saveNodeMap.Clear();
        MapData.Instance.selectedNode.Clear();

        if (MapData.Instance.saveNodeMap.Count == 0)
        {
            for (int i = 1; i <= mapSize; i++)
            {
                CreateMap(i);
            }

            nodeMap[0][0].GetComponent<Animator>().SetBool("isSelect", true);
        }
        else
        { 
            LoadMap();
            LoadLineRenderer();
        }
    }

    public Node CreateNode(NodeType nodeType, Vector2Int location, Transform parent)
    {
        if (nodeType == NodeType.Start || nodeType == NodeType.Boss)
        {
            Vector3 pos = new Vector3(50, location.y * nodeHeightSize - 600, 0);
            return Instantiate(node, pos, Quaternion.identity, parent).SetNodeData(nodeDatas[(int)nodeType], location);
        }
        else
        {
            Vector3 pos = NodeRandomPositions(location);
            return Instantiate(node, pos, Quaternion.identity, parent).SetNodeData(nodeDatas[(int)nodeType], location);
        }
    }

    public List<Node> CreateNodeList()
    {
        List<Node> nodeList = new List<Node>();
        return nodeList;
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
                    LineRenderer line = Instantiate(lineRenderer, nodeMap[nodeMap.Count - 1][curListCount].transform);
                    line.SetPosition(0, Vector3.zero);
                    line.SetPosition(1, newNode.transform.position - nodeMap[nodeMap.Count - 1][curListCount].transform.position);

                    if (curListCount >= nodeMap[nodeMap.Count - 1].Count - 1) break;
                    else
                    {
                        if (v == value - 1 || Random.Range(0, 100) < range) 
                        {
                            curListCount++;
                            range *= 0.4f;
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
                    line.SetPosition(0, node.transform.position);
                    line.SetPosition(1, nodeMap[node.location.y+1][next].transform.position);
                }

            }
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

    private Vector3 NodeRandomPositions(Vector2Int location)
    {
        Vector3 pos = new Vector3(0, 0, 0);
        //float rx = Random.Range((location.x - 1) * nodeWidthSize + nodeImageSize, location.x * nodeWidthSize);
        //float ry = Random.Range((location.y - 1) * nodeHeightSize + nodeImageSize, location.y * nodeHeightSize);

        float rx = location.x * nodeWidthSize;
        float ry = location.y * nodeHeightSize;
        pos.x = rx - 400;
        pos.y = ry - 600;
        return pos;
    }
}