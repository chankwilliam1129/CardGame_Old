using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/GetShield", fileName = "GetShield")]
public class GetShield : CardEffect
{
    public GetShieldEvent shieldEvent;

    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return "�V�[���h��" + GetValueString(value, isFinal) + "����B";
    }

    public override void Execute(Vector2Int value, int power,CardDisplay cardDisplay)
    {
        GetShieldEvent e = Instantiate(shieldEvent, BattleEventManager.Instance.transform);
        e.shield = GetFinalValue(value, power);
        e.target = PlayerArea.Instance.player;
    }
}