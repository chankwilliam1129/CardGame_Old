using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        if (count > enemy.EnemyActions.Count - 1)
        {
            count = 0;
        }
        enemy.EnemyActions[count].type.Execute(enemy.EnemyActions[count].value);
        count = Random.Range(0, enemy.EnemyActions.Count);
    }

    private void Enemy_OnHealthChanged(object sender, System.EventArgs e)
    {
        healthText.text = character.GetHealthPoint().ToString() + "/" + character.GetHealthPointMax().ToString();
        healthBar.rectTransform.localScale = new Vector3(character.GetHealthPoint() * 1.0f / character.GetHealthPointMax() * 1.0f, 1.0f, 1.0f);
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        character.OnHealthChanged -= Enemy_OnHealthChanged;
    }
}