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

    void Start()
    {
        character = GetComponent<Character>();
        character.OnHealthChanged += Character_OnHealthChanged;
    }


    private void Character_OnHealthChanged(object sender, System.EventArgs e)
    {
        healthText.text = character.healthPoint.ToString() + "/" + character.healthPointMax.ToString();
        healthBar.rectTransform.localScale = new Vector3(character.healthPoint * 1.0f / character.healthPointMax * 1.0f, 1.0f, 1.0f);
    }

    void Update()
    {
    }

    private void OnDestroy()
    {
        character.OnHealthChanged -= Character_OnHealthChanged;
    }
}
