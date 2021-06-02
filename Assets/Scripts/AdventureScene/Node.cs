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

    private void LateUpdate()
    {
        foreach (Transform child in transform)
        {
            child.localScale = new Vector3(1.0f / transform.localScale.x, 1.0f / transform.localScale.y, 1.0f);
        }
    }

    public Node SetNodeData(NodeData nodeData, Vector2Int lo)
    {
        data = nodeData;
        location = lo;
        return this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(IsNext()) MapManager.Instance.audioSource.PlayOneShot(MapManager.Instance.sounds[0]);
        GetComponent<Animator>().SetBool("isTouch", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("isTouch", false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GetComponent<Animator>().GetInteger("State") == 3)
        {
            MapData.Instance.playerLocation = location;
            MapData.Instance.selectedNode.Add(location);
            MapData.Instance.ScrollBarPivot = MapManager.Instance.content.GetComponent<RectTransform>().pivot;
            MapData.Instance.ScrollBarValue = MapManager.Instance.scrollbar.value;
            NodetypeCheck(data.nodeType);

            foreach (var l in MapManager.Instance.nodeMap)
            {
                foreach (var n in l)
                {
                    n.StateCheck();
                }
            }
        }
    }

    public void SetPosition()
    {
        float height = MapManager.Instance.nodeHeightSize;
        float weight = MapManager.Instance.nodeWidthSize;

        float posY = height / MapManager.Instance.nodeMap.Count;
        posY *= location.y;

        float posX = location.x * weight - (MapManager.Instance.nodeMap[location.y].Count - 1) * weight * 0.5f;

        transform.position = new Vector3(posX, posY - 600.0f, 0.0f);
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

    private bool IsNext()
    {
        return location.y == MapData.Instance.playerLocation.y + 1 && MapData.Instance.GetPlayerNode().next.Contains(location.x);
    }

    public void StateCheck()
    {
        if (IsSameLocation())
        {
            GetComponent<Animator>().SetInteger("State", 0);
        }
        else if (IsUnderLocation())
        {
            if (MapData.Instance.selectedNode.Contains(location))
            {
                GetComponent<Animator>().SetInteger("State", 2);
            }
            else
            {
                GetComponent<Animator>().SetInteger("State", 1);
            }
        }
        else if (IsNext())
        {
            GetComponent<Animator>().SetInteger("State", 3);
        }
        else if (location.y == MapData.Instance.playerLocation.y + 1 && !MapData.Instance.GetPlayerNode().next.Contains(location.x))
        {
            GetComponent<Animator>().SetInteger("State", 1);
        }
        else GetComponent<Animator>().SetInteger("State", 4);
    }

    public bool NextCheck(Vector2Int loc)
    {
        foreach (var Next in MapManager.Instance.nodeMap[loc.y][loc.x].next)
        {
            if (Next == location.x) return true;
        }
        return false;
    }

    private void NodetypeCheck(NodeType nodeType)
    {
        switch (nodeType)
        {
            case NodeType.MinorEnemy:
                PlayerData.Instance.curBattleSceneData = MapManager.Instance.minor;
                SceneManager.LoadScene("BattleScene");
                break;

            case NodeType.EliteEnemy:
                PlayerData.Instance.curBattleSceneData = MapManager.Instance.elite;
                SceneManager.LoadScene("BattleScene");
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
                PlayerData.Instance.curBattleSceneData = MapManager.Instance.boss;
                SceneManager.LoadScene("BattleScene");
                break;
        }
    }

    private void MysteryCheck()
    {
        float n = Random.Range(0.0f, 100.0f);

        if (n <= 10.0f) SceneManager.LoadScene("TreasureScene");
        else if (n <= 30.0f) SceneManager.LoadScene("StoreScene");
        //else if (n <= 50.0f) SceneManager.LoadScene("StoreScene");
    }
}