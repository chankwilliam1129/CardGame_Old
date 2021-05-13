using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI notEnoughCoinText;
    private float countTime;
    public static TextManager Instance { get; private set; }

    private TextManager()
    {
        Instance = this;
    }

    private void Start()
    {
        coinText.text = "" + Wallet.Instance.coin;
        notEnoughCoinText.text = "ƒRƒCƒ“‚ª‘«‚è‚Ü‚¹‚ñI";
        notEnoughCoinText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (notEnoughCoinText.gameObject.activeSelf)
        {
            countTime += Time.deltaTime;
            if (countTime >= 1.0f)
            {
                countTime = 0;
                notEnoughCoinText.gameObject.SetActive(false);
            }
        }
    }
}
