using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectExecutor : MonoBehaviour
{
    public enum AffectType
    {
        Attack,
        Condition,
        Buff,
        Debuff,
        Heal,
        Shield,
        Special,
        Curse,
        All,
        MAX,
    }

    [System.Serializable]
    public class AffectList
    {
        public List<Affact> List = new List<Affact>();
    }

    [SerializeField]
    public List<AffectList> affectLists = new List<AffectList>();

    public List<CardDisplay> nowModCard;
    public int totalNormalPower;
    public int totalEmptyPower;
    public int totalBrokenPower;

    public static CardEffectExecutor Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for(int i=0;i<(int)AffectType.MAX;i++)
        {
            affectLists.Add(new AffectList());
        }
    }

    public void Execute()
    {
        if (HandCardDisplay.Instance.nowDraggingCard != null)
        {
            foreach (var effect in HandCardDisplay.Instance.nowDraggingCard.data.playEffects)
            {
                effect.type.Execute(effect.value, totalNormalPower);
            }
            BattleDeckManager.Instance.Discard(HandCardDisplay.Instance.nowDraggingCard, HandCardDisplay.Instance.nowDraggingCard.data.removeType);
            foreach (var card in nowModCard)
            {
                BattleDeckManager.Instance.Discard(card, card.data.removeType);
            }
            nowModCard.Clear();
            CountTotalPower();
        }
    }

    public void AddModCard(CardDisplay card)
    {
        nowModCard.Add(card);
        CountTotalPower();
    }

    public void RemoveModCard(CardDisplay card)
    {
        nowModCard.Remove(card);
        CountTotalPower();
    }

    public void CountTotalPower()
    {
        totalNormalPower = 0;
        totalBrokenPower = 0;
        totalEmptyPower = 0;

        foreach (var c in nowModCard)
        {
            totalNormalPower += c.data.normalPower;
            totalBrokenPower += c.data.brokenPower;
            totalEmptyPower += c.data.emptyPower;
        }

        int totolPower = totalNormalPower + totalBrokenPower + totalEmptyPower;

        foreach (var c in HandCardDisplay.Instance.cardDisplayList)
        {
            c.SetUsable(c.data.powerSpace >= totolPower);
        }

        foreach (var card in HandCardDisplay.Instance.cardDisplayList)
        {
            card.powerSpaceDisplay.PowerDisplayUpdate();
        }
    }

    public Vector2Int GetValueAdd(AffectType type)
    {
        Vector2Int value = Vector2Int.zero;
        foreach(var a in affectLists[(int)type].List)
        {
            value += a.GetValueAdd();
        }
        return value;
    }

    public Vector2 GetValueMulti(AffectType type)
    {
        Vector2 value = Vector2.zero;
        foreach (var a in affectLists[(int)type].List)
        {
            value += a.GetValueMulti();
        }
        return value;
    }
}