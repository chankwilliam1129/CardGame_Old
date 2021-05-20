using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Relic/RelicWhitCardEffect", fileName = "RelicData")]
public class RelicCardEffect : Relic
{
    [Header("RelicData")]
    public CardEffect effect;

    public override void Generate(RelicDisplay relicDisplay)
    {
        effect.Generate(Vector2Int.zero, relicDisplay.gameObject);
    }

}
