using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Treasure : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("isTouch", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("isTouch", false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GetTreasure();
        Debug.Log("Get");
    }

    public void GetTreasure()
    {

    }
}
