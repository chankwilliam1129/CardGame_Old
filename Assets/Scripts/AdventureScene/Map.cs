using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public List<Node> widthNodesList = new List<Node>();
    public List<List<Node>> heightNodesList = new List<List<Node>>();

    public void SetWidthNodes(Node node)
    {
        widthNodesList.Add(node);
    }
    public void SetHeightNodes(List<Node> nodeList)
    {
        heightNodesList.Add(nodeList);
    }
    public void SetNodes()
    {
        foreach (var h in heightNodesList)
        {
            foreach (var w in h)
            {
                Node n = w;
                Instantiate(n);
            }
        }
    }
}
