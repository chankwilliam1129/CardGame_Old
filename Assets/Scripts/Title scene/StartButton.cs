using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnClickStartButton()
    {

        if (SceneManager.GetActiveScene().name == "TitleScene")
        {

            SceneManager.LoadScene("AdventureScene"); 
            
        }


        if (SceneManager.GetActiveScene().name == "AdventureScene")
        {

            SceneManager.LoadScene("BattleScene");

        }


        if (SceneManager.GetActiveScene().name == "BattleScene")
        {

            SceneManager.LoadScene("TitleScene");

        }
    }

    
}
