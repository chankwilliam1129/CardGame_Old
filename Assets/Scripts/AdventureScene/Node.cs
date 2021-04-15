using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public NodeData data;
    public int number;
    private void Start()
    {
        GetComponent<Image>().sprite = data.sprite;
    }
}

