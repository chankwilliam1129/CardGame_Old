using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leave : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("AdventureScene");
    }
}
