using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveStore : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
