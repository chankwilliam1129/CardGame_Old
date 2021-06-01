using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDeck : MonoBehaviour
{
    public Transform content;
    public CardDisplay card;

    private void Start()
    {
        foreach (var c in PlayerData.Instance.deck)
        {
            Instantiate(card, content).data = c;
        }
    }

    private void Update()
    {
    }

    public void OnClick()
    {
        Destroy(gameObject);
    }
}