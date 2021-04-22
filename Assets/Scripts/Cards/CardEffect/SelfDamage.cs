using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/SelfDamage", fileName = "SelfDamage")]
public class SelfDamage : CardEffect
{
    public SelfDamageEvent damageEvent;

    public override string GetDescription(Vector2Int value)
    {
        if (value.y != 0) return value.x.ToString() + "(" + value.y.ToString() + ")�_���[�W�������ɗ^����B";
        return value.x.ToString() + "�_���[�W�������ɗ^����B";
    }

    public override void Execute(Vector2Int value, int power)
    {
        SelfDamageEvent e = Instantiate(damageEvent);
        e.damage = value.x + value.y * power;
        e.target = PlayerArea.Instance.player;
    }
}