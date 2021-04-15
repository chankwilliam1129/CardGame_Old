using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Map currentMap;
    public MapGenerator mapGenerator;
    public static MapSetting mapSetting; 

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
