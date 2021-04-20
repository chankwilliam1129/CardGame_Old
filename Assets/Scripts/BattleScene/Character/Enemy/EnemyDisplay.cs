using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EnemyDisplay : MonoBehaviour
{
    private Character character;

    public TextMeshProUGUI healthText;
    public Image healthBar;
    public EnemyData enemy;

    public int count;

    private void Start()
    {
        character = GetComponent<Character>();
        EnemyArea.Instance.enemy = character;
        character.OnHealthChanged += Enemy_OnHealthChanged;
        character.SetHealthPointMax(enemy.health);
        BattleStateManager.Instance.OnEnemyTurnStart += Instance_OnEnemyTurnStart;
        count = 0;

    }

    private void Instance_OnEnemyTurnStart(object sender, System.EventArgs e)
    {

        if(count > enemy.EnemyActions.Count - 1)
        {
            count = 0;
        }


        enemy.EnemyActions[count].type.Execute(enemy.EnemyActions[count].value);


        count = Random.Range(0, enemy.EnemyActions.Count);
        // count++;

        //foreach (EnemyData.EnemyActionData data in enemy.EnemyActions)
        //{
        //    data.type.Execute(data.value);   
        //}
    }

    private void Enemy_OnHealthChanged(object sender, System.EventArgs e)
    {
        healthText.text = character.healthPoint.ToString() + "/" + character.healthPointMax.ToString();
        healthBar.rectTransform.localScale = new Vector3(character.healthPoint * 1.0f / character.healthPointMax * 1.0f, 1.0f, 1.0f);
    }

    private void Update()
    {



    }

    private void OnDestroy()
    {
        character.OnHealthChanged -= Enemy_OnHealthChanged;
    }
}