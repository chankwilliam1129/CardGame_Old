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

    private void Start()
    {
        character = GetComponent<Character>();
        EnemyArea.Instance.enemy = character;
        BattleStateManager.Instance.OnEnemyTurnStart += EnemyTurnStart;
        actionCount = 0;
    }

    private void EnemyTurnStart(object sender, System.EventArgs e)
    {
        if (actionCount > enemy.EnemyActions.Count - 1)
        {
            actionCount = 0;
        }
        enemy.EnemyActions[actionCount].type.Execute(enemy.EnemyActions[actionCount].value);
        actionCount = Random.Range(0, enemy.EnemyActions.Count);
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        BattleStateManager.Instance.OnEnemyTurnStart -= EnemyTurnStart;
    }
}