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
        actionCount = 0;
        AtkCount = Random.Range(1, enemy.Atk_Ntimes);
    }

    private void EnemyTurnStart(object sender, System.EventArgs e)
    {
        //for (int i = 0; i < AtkCount; i++)
        //{
            if (actionCount > enemy.EnemyActions.Count - 1)
            {
                actionCount = 0;
            }
            enemy.EnemyActions[actionCount].type.Execute(enemy.EnemyActions[actionCount].value);
            actionCount = Random.Range(0, enemy.EnemyActions.Count);
        //}
    }
    private void Update()
    {
    }

    private void OnDestroy()
    {
        BattleStateManager.Instance.OnEnemyTurnStart -= EnemyTurnStart;
    }
}