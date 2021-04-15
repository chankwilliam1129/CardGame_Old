using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Map currentMap;
    public MapGenerator mapGenerator;

    private void Start()
    {
        GenerateNewMap();
    }
    public void GenerateNewMap()
    {
        var map = mapGenerator.GetMap();
        currentMap = map;
    }
}
