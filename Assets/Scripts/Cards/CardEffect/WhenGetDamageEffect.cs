using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/WhenGetDamage", fileName = "WhenGetDamage")]
public class WhenGetDamageEffect : CardEffect
{
    public int damage;
    [SerializeField] public List<CardBattleData.Effect> effects;

    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        string text = damage.ToString() + "É_ÉÅÅ[ÉWà»è„éÛÇØÇΩéû:";
        text += "<size=80%>\n";

        foreach (var effect in effects)
        {
            text += "  ";
            text += effect.type.GetDescription(new Vector2Int(effect.value.x, 0), isFinal);
            text += "\n";
        }
        text += "</size>";

        return text;
    }

    public override void Generate(Vector2Int value, GameObject cardDisplay)
    {
        WhenGetDamage whenGetDamage = cardDisplay.gameObject.AddComponent<WhenGetDamage>();
        whenGetDamage.effects = effects;
        whenGetDamage.damage = damage;
    }
}
