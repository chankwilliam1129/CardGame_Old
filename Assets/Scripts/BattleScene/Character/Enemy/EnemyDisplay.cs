using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyDisplay : MonoBehaviour
{
    private Character character;
    public EnemyData enemy;
    public int actionCount;
    public int AtkCount;

    private void Start()
    {
        character = GetComponent<Character>();
        EnemyArea.Instance.enemy = character;
        BattleStateManager.Instance.OnEnemyTurnStart += EnemyTurnStart;
        BattleStateManager.Instance.OnEnemyTurnEnd += OnEnemyTurnEnd;
        actionCount = 0;
        if (enemy.isActionRandom) actionCount = Random.Range(0, 3);
    }

    private void EnemyTurnStart(object sender, System.EventArgs e)
    {
        switch(actionCount)
        {
            case 0:
                Execute(enemy.EnemyNormalActions1); 
                break;
            case 1:
                Execute(enemy.EnemyNormalActions2);
                break;
            case 2:
                Execute(enemy.EnemyNormalActions3);
                break;
            case 3:
                Execute(enemy.EnemySpecialActions1);
                break;
            case 4:
                Execute(enemy.EnemySpecialActions2);
                break;
            case 5:
                Execute(enemy.EnemySpecialActions3);
                break;
        }

    }

    private void OnEnemyTurnEnd(object sender, System.EventArgs e)
    {
        if (enemy.isActionRandom)
        {
            if (!isUseSpecial()) actionCount = Random.Range(0, 3);
            else actionCount = Random.Range(3, 6);
        }
        else if (!isUseSpecial())
        {
            actionCount = actionCount + 1 > 2 ? 0 : actionCount + 1;
        }
        else actionCount = actionCount + 1 > 5 ? 3 : actionCount + 1;
    }

    private void Execute(List<EnemyData.EnemyActionData> enemyActions)
    {
        foreach(var a in enemyActions)
        {
            a.type.Execute(a.value);
        }
    }

    private bool isUseSpecial()
    {
        if (character.GetHealthPoint() <= 0) return true;
        return (character.GetHealthPointMax() / character.GetHealthPoint()) >= 2;
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        BattleStateManager.Instance.OnEnemyTurnStart -= EnemyTurnStart;
        BattleStateManager.Instance.OnEnemyTurnEnd -= OnEnemyTurnEnd;
    }
}