using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EnemyDisplay : MonoBehaviour
{
    private Character character;
    private EnemyArea enemyArea;

    public TextMeshProUGUI healthText;
    public Image healthBar;

    private void Start()
    {
        enemyArea = GetComponentInParent<EnemyArea>();
        character = GetComponent<Character>();
        character.OnHealthChanged += Character_OnHealthChanged;
    }

    private void Character_OnHealthChanged(object sender, System.EventArgs e)
    {
        healthText.text = character.healthPoint.ToString() + "/" + character.healthPointMax.ToString();
        healthBar.rectTransform.localScale = new Vector3(character.healthPoint * 1.0f / character.healthPointMax * 1.0f, 1.0f, 1.0f);
    }

    private void Update()
    {
    }

    public void OnPointEnter()
    {
        enemyArea.nowSelectEnemy = character;
    }

    public void OnPointExit()
    {
        enemyArea.nowSelectEnemy = null;
    }

    public void OnDrop()
    {
    }

    private void OnDestroy()
    {
        character.OnHealthChanged -= Character_OnHealthChanged;
    }
}