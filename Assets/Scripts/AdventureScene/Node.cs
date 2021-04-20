using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Node : MonoBehaviour
{
    public NodeData data;
    private void Start()
    {
        GetComponent<Image>().sprite = data.sprite;
    }
    public Node SetNodeData(NodeData nodeData)
    {
        data = nodeData;
        return this;
    }
    
    public void NodePointerEnter()
    {
        if (this.data.nodeType == NodeType.EliteEnemy)
        {
            Debug.Log("EliteEnemy");         
        }
        else if (this.data.nodeType == NodeType.MinorEnemy)
        {
            Debug.Log("MinorEnemy");
        }
    }
    public void NodePointerClick()
    {
        if (this.data.nodeType == NodeType.EliteEnemy)
        {
            SceneManager.LoadScene("BattleScene");
        }
        else if (this.data.nodeType == NodeType.MinorEnemy)
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
}
