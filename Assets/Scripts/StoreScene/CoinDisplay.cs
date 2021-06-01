using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        text.text = PlayerData.Instance.coin.ToString();
    }

    private void Update()
    {
        if (text.text != PlayerData.Instance.coin.ToString())
        {
            text.text = PlayerData.Instance.coin.ToString();
        }
    }

}
