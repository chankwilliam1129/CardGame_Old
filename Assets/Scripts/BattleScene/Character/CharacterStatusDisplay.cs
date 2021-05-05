using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CharacterStatusDisplay : MonoBehaviour
{
    public Character character;

    public TextMeshProUGUI healthText;
    public Image healthBar;

    public TextMeshProUGUI shieldText;
    public Image shieldBar;

    private void Start()
    {
        character.OnHealthChanged += Healthchanged;
        character.OnShieldChanged += ShieldChanged;

        character.characterEvent.StatusSetUp();
    }

    private void Healthchanged(object sender, System.EventArgs e)
    {
        healthText.text = character.GetHealthPoint().ToString() + "/" + character.GetHealthPointMax().ToString();
        healthBar.rectTransform.localScale = new Vector3(character.GetHealthPoint() * 1.0f / character.GetHealthPointMax() * 1.0f, 1.0f, 1.0f);
    }

    private void ShieldChanged(object sender, System.EventArgs e)
    {
        shieldText.text = character.GetShield().ToString();
        shieldBar.rectTransform.localScale = new Vector3(Mathf.Min(1.0f, character.GetShield() * 1.0f / character.GetHealthPointMax() * 1.0f), 1.0f, 1.0f);
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        character.OnHealthChanged -= Healthchanged;
        character.OnShieldChanged -= ShieldChanged;
    }
}