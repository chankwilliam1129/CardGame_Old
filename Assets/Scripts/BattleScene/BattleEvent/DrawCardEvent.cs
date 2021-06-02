using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardEvent : MonoBehaviour
{
    private void Start()
    {
        //GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        BattleDeckManager.Instance.DrawCard();
    }
}