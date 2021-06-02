using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyDisplay : MonoBehaviour
{
    public Character character;
    public EnemyData enemy;
    public Transform enemyActionGroup;
    public EnemyActionDisplay enemyAction;
    public int level;
    public int actionCount;

    private void Start()
    {
        if(enemy == null)enemy = PlayerData.Instance.curBattleSceneData.GetEnemy();
        //level = MapData.Instance.playerLocation.y;
        level = 9;
        BattleStateManager.Instance.OnEnemyTurnStart += EnemyTurnStart;
        BattleStateManager.Instance.OnEnemyTurnEnd += OnEnemyTurnEnd;
        actionCount = 0;
        if (enemy.isActionRandom) actionCount = Random.Range(0, 5);
        switch (actionCount)
        {
            case 0: Setup(enemy.EnemyNormalActions1); break;
            case 1: Setup(enemy.EnemyNormalActions2); break;
            case 2: Setup(enemy.EnemyNormalActions3); break;
            case 3: Setup(enemy.EnemyNormalActions4); break;
            case 4: Setup(enemy.EnemyNormalActions5); break;
            case 5: Setup(enemy.EnemySpecialActions1); break;
            case 6: Setup(enemy.EnemySpecialActions2); break;
            case 7: Setup(enemy.EnemySpecialActions3); break;
            case 8: Setup(enemy.EnemySpecialActions4); break;
            case 9: Setup(enemy.EnemySpecialActions5); break;
        }

    }

    private void EnemyTurnStart(object sender, System.EventArgs e)
    {
        switch(actionCount)
        {
            case 0: Execute(enemy.EnemyNormalActions1); break;
            case 1: Execute(enemy.EnemyNormalActions2); break;
            case 2: Execute(enemy.EnemyNormalActions3); break;
            case 3: Execute(enemy.EnemyNormalActions4); break;
            case 4: Execute(enemy.EnemyNormalActions5); break;
            case 5: Execute(enemy.EnemySpecialActions1); break;
            case 6: Execute(enemy.EnemySpecialActions2); break;
            case 7: Execute(enemy.EnemySpecialActions3); break;
            case 8: Execute(enemy.EnemySpecialActions4); break;
            case 9: Execute(enemy.EnemySpecialActions5); break;
            default: Debug.Log("EnemyCountError:" + actionCount); break;
        }

    }

    private void OnEnemyTurnEnd(object sender, System.EventArgs e)
    {
        if (enemy.isActionRandom)
        {
            if (!isUseSpecial()) actionCount = Random.Range(0, 5);
            else actionCount = Random.Range(5, 9);
        }
        else if (!isUseSpecial())
        {
            actionCount = actionCount + 1 > 4 ? 0 : actionCount + 1;
        }
        else actionCount = actionCount + 1 > 9 ? 5 : actionCount + 1;

        foreach (Transform child in enemyActionGroup)
        {
            Destroy(child.gameObject);
        }

        switch (actionCount)
        {
            case 0: Setup(enemy.EnemyNormalActions1); break;
            case 1: Setup(enemy.EnemyNormalActions2); break;
            case 2: Setup(enemy.EnemyNormalActions3); break;
            case 3: Setup(enemy.EnemyNormalActions4); break;
            case 4: Setup(enemy.EnemyNormalActions5); break;
            case 5: Setup(enemy.EnemySpecialActions1); break;
            case 6: Setup(enemy.EnemySpecialActions2); break;
            case 7: Setup(enemy.EnemySpecialActions3); break;
            case 8: Setup(enemy.EnemySpecialActions4); break;
            case 9: Setup(enemy.EnemySpecialActions5); break;
        }

    }

    private void Execute(List<EnemyData.EnemyActionData> enemyActions)
    {
        foreach(var a in enemyActions)
        {
            a.type.Execute(a.value, level);
        }
    }

    private void Setup(List<EnemyData.EnemyActionData> enemyActions)
    {
        foreach (var a in enemyActions)
        {
            Instantiate(enemyAction, enemyActionGroup).Setup(a.type, a.value, level);
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