using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDataManager : MonoBehaviour
{
    public Transform canvas;
    public NodeData[] nodeDatas = new NodeData[(int)NodeType.Max];
    public Node node;
    public MapSetting mapSetting;

    public Node SetNodeData(NodeType nodeType)
    {
        Instantiate(node, SetRandomNodePositions(), Quaternion.identity, canvas);
        node.data = nodeDatas[(int)nodeType];    
        return node;
    }
    public Node SetNodeData(int num)
    {
        Instantiate(node, canvas);
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
    public Vector3 SetRandomNodePositions()
    {
        float x = Random.Range(mapSetting.nodeMinMaxPositionX.min, mapSetting.nodeMinMaxPositionX.max);
        float y = Random.Range(mapSetting.nodeMinMaxPositionY.min, mapSetting.nodeMinMaxPositionY.max);
        Vector2 pos = canvas.GetComponent<Transform>().position;
        return (new Vector3(x + pos.x, y + pos.y, 0));
    }
}
