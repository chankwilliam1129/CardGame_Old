using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenGetDamage : MonoBehaviour
{
    public int damage;
    [SerializeField] public List<CardBattleData.Effect> effects;

    private void Start()
    {
        if (PlayerArea.Instance != null)
        {
            PlayerArea.Instance.player.characterEvent.OnGetDamaged += GetDamage;
        }
    }

    private void OnDestroy()
    {
        if (PlayerArea.Instance != null)
        {
            PlayerArea.Instance.player.characterEvent.OnGetDamaged -= GetDamage;
        }
    }

    private void GetDamage(object sender, System.EventArgs e)
    {
        DamageEventArgs args = e as DamageEventArgs;
        if (args.damage >= damage)
        {
            foreach (var effect in effects)
            {
                effect.type.Execute(effect.value, 0, GetComponent<CardDisplay>());
            }
        }

    }
}
