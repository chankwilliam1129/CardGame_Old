using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDescription : MonoBehaviour
{
    public CardDisplay cardDisplay;
    public CardEffectDescription description;

    public float positionOffset;

    private void Start()
    {
        Vector3 pos = transform.position;
        foreach (CardBattleData.Effect effect in cardDisplay.data.playEffects)
        {
            Instantiate(description, pos, transform.rotation, transform).SetUp(effect);
            pos.y += positionOffset;
        }
    }

    private void Update()
    {
    }
}