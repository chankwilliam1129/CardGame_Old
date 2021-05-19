using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public NodeData data;
    public Vector2Int location;

    private float WidthSize = 110.0f;
    private float HeightSize = 100.0f;

    private void Start()
    {
        GetComponent<Image>().sprite = data.sprite;
        transform.localPosition = SetNodePositions();
    }

    public Node SetNodeData(NodeData nodeData, Vector2Int lo)
    {
        data = nodeData;
        location = lo;
        return this;
    } 

    public Vector3 SetNodePositions()
    {
        if (location.x == 0 && location.y == 0) 
        {
            return new Vector3(2 * WidthSize, location.y * HeightSize, 0);
        }
        return new Vector3(location.x * WidthSize, location.y * HeightSize, 0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("isTouch", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("isTouch", false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {    
        if (CanWalk()) 
        {
            Node curNode = MapManager.Instance.GetNodeList(MapData.Instance.playerLocation.y)[MapData.Instance.playerLocation.x];
            curNode.GetComponent<Animator>().SetBool("isSelect", false);
            curNode.GetComponent<Animator>().SetBool("isPass", false);
            curNode.GetComponent<Animator>().SetBool("isSelected", true);
 
            MapData.Instance.playerLocation = location;
            MapData.Instance.selectedNode.Add(location);

            GetComponent<Animator>().SetBool("isSelect", true);
            foreach (var n in MapManager.Instance.GetNodeList(MapData.Instance.playerLocation.y))
            {
                if (n != this) n.GetComponent<Animator>().SetBool("isPass", true);
            }

            NodetypeCheck(data.nodeType);          
        }
    }

    private bool CanWalk()
    {       
        return IsNextLocation();
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
        return location.y < MapData.Instance.playerLocation.y || (location.y == MapData.Instance.playerLocation.y && location.x != MapData.Instance.playerLocation.x);
    }

    private bool IsSameLocation()
    {
        return location == MapData.Instance.playerLocation;
    }

    public void StateCheck()
    {
        if (IsUnderLocation()) GetComponent<Animator>().SetBool("isPass", true);
        if (IsSameLocation())
        {
            GetComponent<Animator>().SetBool("isTouch", true);
            GetComponent<Animator>().SetBool("isSelect", true);
            GetComponent<Animator>().SetBool("isPass", false);
        }
        else if (MapData.Instance.selectedNode.FindIndex(n => n == location) != -1)
        {
            GetComponent<Animator>().SetBool("isPass", false);
            GetComponent<Animator>().SetBool("isSelected", true);
        }
    }

    private void NodetypeCheck(NodeType nodeType)
    {
        switch(nodeType)
        {
            case NodeType.MinorEnemy:
                break;
            case NodeType.EliteEnemy:
                break;
            case NodeType.Mystery:
                MysteryCheck();
                break;
            case NodeType.Treasure:
                break;
            case NodeType.Store:
                SceneManager.LoadScene("StoreScene");
                break;
            case NodeType.Boss:
                break;
        }
    }

    private void MysteryCheck()
    {
        float n = Random.Range(0.0f, 100.0f);

        if (n <= 30.0f) SceneManager.LoadScene("StoreScene");
        //else if (n <= 50.0f) SceneManager.LoadScene("StoreScene");
    }
}
