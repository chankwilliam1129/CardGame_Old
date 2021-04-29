using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Node : MonoBehaviour
{
    public NodeData data;
    public Vector2Int location;

    private void Start()
    {
        GetComponent<Image>().sprite = data.sprite;
        transform.localPosition = new Vector3(location.x * 100, location.y * 100, 0);
    }
    private void Update()
    {
        if (IsUnderLocation())
        {
            GetComponent<Animator>().SetBool("isPass", true);
        }
    }
    public Node SetNodeData(NodeData nodeData, Vector2Int lo)
    {
        data = nodeData;
        location = lo;
        return this;
    } 
    public void NodePointerEnter()
    {
        if (IsNextLocation())
        {
            GetComponent<Animator>().SetBool("isTouch", true);
        }
    }

    public void NodePointerExit()
    {
        GetComponent<Animator>().SetBool("isTouch", false);
    }

    public void NodePointerClick()
    {
        //if (this.data.nodeType == NodeType.EliteEnemy)
        //{
        //    SceneManager.LoadScene("BattleScene");
        //}
        
        if (IsNextLocation()) 
        {
            MapData.Instance.playerLocation = location;
            GetComponent<Animator>().SetBool("isSelect", true);
        }
    }

    private bool IsNextLocation()
    {
        return location.y == MapData.Instance.playerLocation.y + 1;
    }
    private bool IsUpLocation()
    {
        return location.y > MapData.Instance.playerLocation.y; 
    } 
    private bool IsUnderLocation()
    {
        return location.y < MapData.Instance.playerLocation.y;
    }
    private bool IsSameLocation()
    {
        return location.y == MapData.Instance.playerLocation.y;
    }
}
