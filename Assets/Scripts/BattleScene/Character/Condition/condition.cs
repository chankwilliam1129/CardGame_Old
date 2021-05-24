using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public abstract class Condition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int GetDamage;
    public int stack;
    public TextMeshProUGUI text;
    public GameObject descriptionObject;
    public TextMeshProUGUI descriptionText;

    public Character character;
    public string conditionName;
    [TextArea(1, 3)] public string description;
    public Color color;

    public abstract Condition Exist(Character character);

    public abstract void Add(int value);

    public abstract void DestoryEvent();

    public string GetText()
    {
        return "<#" + ColorUtility.ToHtmlStringRGB(color) + ">" + conditionName + "</color>";
    }

    private void OnDestroy()
    {
        DestoryEvent();
        character.conditionList.Remove(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionText.text = description;
        descriptionObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionObject.SetActive(false);
    }
}