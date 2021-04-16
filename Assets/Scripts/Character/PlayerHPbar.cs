using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerHPbar : MonoBehaviour
{

    private Character character;

    public TextMeshProUGUI hptext;
    public Image hpbar;

    public int MaxHp;

    // Start is called before the first frame update
    private void Start()
    {
        character = GetComponent<Character>();
        character.OnHealthChanged += Player_Healthchanged;
        character.SetHealthPointMax(MaxHp);
    }
    private void Player_Healthchanged(object sender, System.EventArgs e)
    {
        hptext.text = character.healthPoint.ToString() + "/" + character.healthPointMax.ToString();
        hpbar.rectTransform.localScale = new Vector3(character.healthPoint * 1.0f / character.healthPointMax * 1.0f, 1.0f, 1.0f);
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnDestroy()
    {
        character.OnHealthChanged -= Player_Healthchanged;
    }

}
