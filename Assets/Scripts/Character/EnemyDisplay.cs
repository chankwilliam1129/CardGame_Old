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

    private void Start()
    {
        character = GetComponent<Character>();
        character.OnHealthChanged += Enemy_OnHealthChanged;
        character.SetHealthPointMax(10);
    }

    private void Enemy_OnHealthChanged(object sender, System.EventArgs e)
    {
        healthText.text = character.healthPoint.ToString() + "/" + character.healthPointMax.ToString();
        healthBar.rectTransform.localScale = new Vector3(character.healthPoint * 1.0f / character.healthPointMax * 1.0f, 1.0f, 1.0f);
    }

    private void Update()
    {
    }

    public void OnPointEnter()
    {
        EnemyArea.Instance.nowSelectEnemy = character;
    }

    public void OnPointExit()
    {
        EnemyArea.Instance.nowSelectEnemy = null;
    }

    public void OnDrop()
    {
    }

    private void OnDestroy()
    {
        character.OnHealthChanged -= Enemy_OnHealthChanged;
    }
}