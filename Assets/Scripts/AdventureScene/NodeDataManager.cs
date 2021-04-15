using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDataManager : MonoBehaviour
{
    public Transform canvas;
    public NodeData[] nodeDatas = new NodeData[(int)NodeType.Max];
    public Node node;

    public Node SetNodeData(NodeType nodeType)
    {
        Instantiate(node, canvas);
        node.data = nodeDatas[(int)nodeType];    
        return node;
    }
    public Node SetNodeData(NodeType nodeType, Vector3 pos)
    {
        Quaternion q = GetComponent<Quaternion>();
        Instantiate(node, pos, q,canvas);   
        node.data = nodeDatas[(int)nodeType];
        return node;
    }
    public Node SetNodeData(int num)
    {
        Instantiate(node, canvas);
        node.data = nodeDatas[num];
        return node;
    }
    public Node SetNodeData(int num, Vector3 pos)
    {
        Quaternion q = GetComponent<Quaternion>();
        Instantiate(node, pos, q, canvas);
        node.data = nodeDatas[num];
        return node;
    }

    public Node SetRandomNode(int min, int max)
    {
        int num = Random.Range(min, max);
        Instantiate(node);
        node.data = nodeDatas[num];
        return node;
    }
}
