using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/SelectCard", fileName = "SelectCard")]
public class SelectCard : CardEffect
{
    public CardSelectGroup cardSelect;
    public List<Card> cardList;

    public override string GetDescription(Vector2Int value, bool isFinal)
    {
        return "カードを" + GetValueString(value, isFinal) + "枚生成し、その中の１枚を手札に加える。";
    }

    public override void Execute(Vector2Int value, int power)
    {
        CardSelectGroup group = Instantiate(cardSelect, BattleEventManager.Instance.transform);
        group.selectNumber = 1;

        int draw = GetFinalValue(value, power);
        for (int i = 0; i < draw; i++)
        {
            group.Add(cardList[Random.Range(0, cardList.Count)].battleData);
        }
    }
}