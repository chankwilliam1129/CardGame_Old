using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Affact : MonoBehaviour
{
    public CardEffectExecutor.AffectType type;

    public Vector2Int valueAdd;
    public Vector2 valueMulti;

    void Start()
    {
        CardEffectExecutor.Instance.affectLists[(int)type].List.Add(this);
        foreach(var card in HandCardDisplay.Instance.cardDisplayList)
        {
            card.cardDescription.DescriptionUpdate();
        }
    }

    private void OnDestroy()
    {
        CardEffectExecutor.Instance.affectLists[(int)type].List.Remove(this);
        foreach (var card in HandCardDisplay.Instance.cardDisplayList)
        {
            card.cardDescription.DescriptionUpdate();
        }
    }

    public virtual Vector2Int GetValueAdd()
    {
        return valueAdd;
    }

    public virtual Vector2 GetValueMulti()
    {
        return valueMulti;
    }
}
