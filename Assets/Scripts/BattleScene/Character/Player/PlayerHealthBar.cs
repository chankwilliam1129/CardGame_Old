using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerHealthBar : MonoBehaviour
{
    private Character character;

    public TextMeshProUGUI hptext;
    public Image hpbar;

    public int MaxHp;

    // Start is called before the first frame update
    private void Start()
    {
        character = transform.parent.GetComponent<Character>();
        character.OnHealthChanged += Player_Healthchanged;
        character.SetHealthPointMax(MaxHp);
    }

    private void Player_Healthchanged(object sender, System.EventArgs e)
    {
        hptext.text = character.GetHealthPoint().ToString() + "/" + character.GetHealthPointMax().ToString();
        hpbar.rectTransform.localScale = new Vector3(character.GetHealthPoint() * 1.0f / character.GetHealthPointMax() * 1.0f, 1.0f, 1.0f);
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        character.OnHealthChanged -= Player_Healthchanged;
    }
}