using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class EnemyActionDisplay : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public TextMeshProUGUI number;
    public TextMeshProUGUI text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("isSelect", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("isSelect", false);
    }

    public void Setup(EnemyAction enemyAction,int value)
    {
        text.text = enemyAction.GetDescription(value);
        number.text = value.ToString();
        GetComponent<Image>().sprite = enemyAction.sprite;
    }

}
