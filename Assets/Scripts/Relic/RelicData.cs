using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Relic/RelicData", fileName = "RelicData")]
public class RelicData : Relic
{
    [Header("CardEffect")]
    public bool isEffect;
    public CardEffect effect;

    [Header("PlayerData")]
    public bool isPlayerData;
    public int health;
    public int energy;
    public int drawCard;
    public float shieldClear;

    [Header("Affect")]
    public bool isAffect;
    public CardEffectExecutor.AffectType type;
    public Vector2Int valueAdd;
    public Vector2 valueMulti;

    public override void Add()
    {
        if (isPlayerData)
        {
            PlayerData.Instance.health += health;
            PlayerData.Instance.energy += energy;
            PlayerData.Instance.drawCard += drawCard;
            PlayerData.Instance.shieldClear += shieldClear;
        }
    }

    public override void Generate(RelicDisplay relicDisplay)
    {
        if(isEffect) effect.Generate(Vector2Int.zero, relicDisplay.gameObject);
        if (isAffect)
        {
            Affact a = relicDisplay.gameObject.AddComponent<Affact>();
            a.type = type;
            a.valueAdd = valueAdd;
            a.valueMulti = valueMulti;
        }
    }

}
