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
    public List<int> next;

    private void Start()
    {
        GetComponent<Image>().sprite = data.sprite;
    }

    public Node SetNodeData(NodeData nodeData, Vector2Int lo)
    {
        data = nodeData;
        location = lo;
        return this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("isTouch", true);

        if (!GetComponent<Animator>().GetBool("isPass") && !GetComponent<Animator>().GetBool("isSelected") && !GetComponent<Animator>().GetBool("isSelected")) 
        {
            Transform children = GetComponentInChildren<Transform>();
            foreach (Transform c in children)
            {
                c.GetComponent<Animator>().SetBool("isTouch", true);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("isTouch", false);

        if (!GetComponent<Animator>().GetBool("isPass") && !GetComponent<Animator>().GetBool("isSelected") && !GetComponent<Animator>().GetBool("isSelected"))
        {
            Transform children = GetComponentInChildren<Transform>();
            foreach (Transform c in children)
            {
                c.GetComponent<Animator>().SetBool("isTouch", false);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {    
        if (IsNextLocation()) 
        {
            foreach (var Next in MapManager.Instance.nodeMap[MapData.Instance.playerLocation.y][MapData.Instance.playerLocation.x].next)
            {
                if (Next == location.x)
                {
                    Node curNode = MapManager.Instance.nodeMap[MapData.Instance.playerLocation.y][MapData.Instance.playerLocation.x];
                    curNode.GetComponent<Animator>().SetBool("isSelect", false);
                    curNode.GetComponent<Animator>().SetBool("isPass", false);
                    curNode.GetComponent<Animator>().SetBool("isSelected", true);

                    Transform children = curNode.GetComponentInChildren<Transform>();
                    foreach (Transform c in children)
                    {
                        c.GetComponent<Animator>().SetBool("isSelect", false);
                        c.GetComponent<Animator>().SetBool("isSelected", true);
                    }

                    MapData.Instance.playerLocation = location;
                    MapData.Instance.selectedNode.Add(location);

                    GetComponent<Animator>().SetBool("isSelect", true);
                    foreach (var n in MapManager.Instance.nodeMap[MapData.Instance.playerLocation.y])
                    {
                        if (n != this) n.GetComponent<Animator>().SetBool("isPass", true);
                    }

                    if (MapData.Instance.playerLocation.y < MapManager.Instance.mapSize - 1) 
                    {
                        foreach (var node in MapManager.Instance.nodeMap[MapData.Instance.playerLocation.y + 1])
                        {
                            if (!node.NextCheck()) node.GetComponent<Animator>().SetBool("isPass", true);
                        }
                    }

                    children = MapManager.Instance.nodeMap[MapData.Instance.playerLocation.y][MapData.Instance.playerLocation.x].GetComponentInChildren<Transform>();
                    foreach (Transform c in children)
                    {
                        c.GetComponent<Animator>().SetBool("isSelect", true);
                    }

                    NodetypeCheck(data.nodeType);
                   
                    break;
                }
            }
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
        return location.y < MapData.Instance.playerLocation.y || (location.y == MapData.Instance.playerLocation.y && location.x != MapData.Instance.playerLocation.x);
    }

    private bool IsSameLocation()
    {
        return location == MapData.Instance.playerLocation;
    }

    public void StateCheck()
    {
        Transform children = GetComponentInChildren<Transform>();
       
        if (IsUnderLocation()) GetComponent<Animator>().SetBool("isPass", true);
        if (IsSameLocation())
        {
            GetComponent<Animator>().SetBool("isTouch", true);
            GetComponent<Animator>().SetBool("isSelect", true);
            GetComponent<Animator>().SetBool("isPass", false);

            foreach (Transform c in children)
            {
                c.GetComponent<Animator>().SetBool("isSelect", true);
                c.GetComponent<Animator>().SetBool("isSelected", false);
            }
        }
        else if (MapData.Instance.selectedNode.FindIndex(n => n == location) != -1)
        {
            GetComponent<Animator>().SetBool("isPass", false);
            GetComponent<Animator>().SetBool("isSelected", true);

            foreach (Transform c in children)
            {
                c.GetComponent<Animator>().SetBool("isSelect", false);
                c.GetComponent<Animator>().SetBool("isSelected", true);
            }
        }
    }

    public bool NextCheck()
    {
        foreach(var Next in MapManager.Instance.nodeMap[MapData.Instance.playerLocation.y][MapData.Instance.playerLocation.x].next)
        {
            if (Next == location.x) return true;
        }
        return false;
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
                SceneManager.LoadScene("TreasureScene");
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
