using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCardEvent : MonoBehaviour
{
    public CardDisplay card;
    public Transform trans;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        card.data.drawType = BattleDeckManager.DrawType.ByCreating;
        if (trans) BattleDeckManager.Instance.DrawCard(card, trans.position);
        else BattleDeckManager.Instance.DrawCard(card);
    }
}