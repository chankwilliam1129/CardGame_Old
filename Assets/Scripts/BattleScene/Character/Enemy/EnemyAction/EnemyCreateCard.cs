using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyAction/EnemyCreateCard", fileName = "EnemyCreateCard")]

public class EnemyCreateCard : EnemyAction
{
    public CreateCardEvent createCardEvent;
    public Card card;


    public override void Execute(int value)
    {
        int draw = value;
        for (int i = 0; i < draw; i++)
        {
            Instantiate(createCardEvent, BattleEventManager.Instance.transform).card.data = card.battleData;
        }
    }
}