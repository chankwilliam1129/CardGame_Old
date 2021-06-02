using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public PlayerData playerData;
    public MapData mapData;

    public void OnClickStartButton()
    {
        playerData.StartNewGame();
        mapData.StartNewGame();
        SceneManager.LoadScene("AdventureScene");
    }
}