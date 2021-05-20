using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class RelicDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Relic relicData;

    public Image image;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("isSelect", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("isSelect", false);
    }

    void Start()
    {
        image.sprite = relicData.image;
        nameText.text = relicData.name;
        descriptionText.text = relicData.descriptionText;

        relicData.Generate(this);
    }

    void Update()
    {
        
    }
}
