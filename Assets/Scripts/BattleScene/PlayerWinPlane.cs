using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerWinPlane : MonoBehaviour
{
    public BattleEndCardSelectGroup selectGroup;
    public TextMeshProUGUI coinText;

    public int coin;

    void Start()
    {
        foreach(var c in selectGroup.cardList)
        {
            c.data = PlayerData.Instance.curBattleSceneData.GetCard();
            c.SetUp();
        }
        coin = PlayerData.Instance.curBattleSceneData.coin;

        coinText.text = coin.ToString();
    }

    void Update()
    {
        
    }

    public void ButtonClick()
    {
        PlayerData.Instance.coin += coin;
        SceneManager.LoadScene("AdventureScene");
    }

    public void ButtonLoseClick()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
