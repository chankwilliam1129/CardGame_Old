using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tset : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("TreasureScene");
    }

}
