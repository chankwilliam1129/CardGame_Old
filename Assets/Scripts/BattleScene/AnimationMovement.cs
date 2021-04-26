using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AnimationMovement
{
    void Init();
    void Activate();
    bool IsEnd();
}

public class DrawCardAnimation : AnimationMovement
{
    float timeCounter;

    public void Init()
    {
        timeCounter = 0.5f;
        //BattleDeckManager.DrawCard(BattleDeckManager.DrawType.FromBattleDeck);
    }
    public void Activate()
    {
        timeCounter -= Time.deltaTime;
    }

    public bool IsEnd()
    {
        return timeCounter < 0.0f;
    }
}

