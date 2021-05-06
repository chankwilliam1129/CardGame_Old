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
    public Image healthSubBar;

    private bool isHealthChange;
    private float healthChangeTimeCounter;
    private float healthCur;
    private float healthTarget;

    public TextMeshProUGUI shieldText;
    public Image shieldBar;
    public Image shieldSubBar;

    private bool isShieldChange;
    private float shieldChangeTimeCounter;
    private float shieldCur;
    private float shieldTarget;


    public AnimationCurve changeCurve;
    public float changeTime;


    private void Start()
    {
        character.OnHealthChanged += Healthchanged;
        character.OnShieldChanged += ShieldChanged;

        healthCur = 1.0f;
        shieldCur = 1.0f;

        character.characterEvent.StatusSetUp();
        character.ChangeHealthPoint(0);
        character.ChangeShield(0);
    }

    private void Healthchanged(object sender, System.EventArgs e)
    {
        healthText.text = character.GetHealthPoint().ToString() + "/" + character.GetHealthPointMax().ToString();
        healthBar.rectTransform.localScale = new Vector3(character.GetHealthPoint() * 1.0f / character.GetHealthPointMax() * 1.0f, 1.0f, 1.0f);

        if(healthBar.rectTransform.localScale.x != healthSubBar.rectTransform.localScale.x)
        {
            healthTarget = healthBar.rectTransform.localScale.x;
            healthCur = healthSubBar.rectTransform.localScale.x;
            healthChangeTimeCounter = 0.0f;
            isHealthChange = true;
        }
    }

    private void ShieldChanged(object sender, System.EventArgs e)
    {
        shieldText.text = character.GetShield().ToString();
        shieldBar.rectTransform.localScale = new Vector3(Mathf.Min(1.0f, character.GetShield() * 1.0f / character.GetHealthPointMax() * 1.0f), 1.0f, 1.0f);

        if (shieldBar.rectTransform.localScale.x != shieldSubBar.rectTransform.localScale.x)
        {
            shieldTarget = shieldBar.rectTransform.localScale.x;
            shieldCur = shieldSubBar.rectTransform.localScale.x;
            shieldChangeTimeCounter = 0.0f;
            isShieldChange = true;
        }
    }

    private void Update()
    {
        if(isHealthChange)
        {
            if(healthChangeTimeCounter> changeTime)
            {
                healthChangeTimeCounter = changeTime;
                isHealthChange = false;
            }
            float scaleX = healthCur + (healthTarget - healthCur) * changeCurve.Evaluate(healthChangeTimeCounter / changeTime);
            healthSubBar.rectTransform.localScale = new Vector3(scaleX, 1.0f, 1.0f);
            healthChangeTimeCounter += Time.deltaTime;
        }

        if (isShieldChange)
        {
            if (shieldChangeTimeCounter > changeTime)
            {
                shieldChangeTimeCounter = changeTime;
                isShieldChange = false;
            }
            float scaleX = shieldCur + (shieldTarget - shieldCur) * changeCurve.Evaluate(shieldChangeTimeCounter / changeTime);
            shieldSubBar.rectTransform.localScale = new Vector3(scaleX, 1.0f, 1.0f);
            shieldChangeTimeCounter += Time.deltaTime;
        }

    }

    private void OnDestroy()
    {
        character.OnHealthChanged -= Healthchanged;
        character.OnShieldChanged -= ShieldChanged;
    }
}