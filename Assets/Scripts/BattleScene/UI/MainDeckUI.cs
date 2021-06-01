using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MainDeckUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TextMeshProUGUI total;
    public CardDisplay card;
    public ShowDeck showDeck;

    private ShowDeck curShowDeck;
    public static MainDeckUI Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        UpdateTotalNumber();
    }

    public void UpdateTotalNumber()
    {
        total.text = PlayerData.Instance.deck.Count.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("isSelect", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("isSelect", false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (curShowDeck) Destroy(curShowDeck.gameObject);
            else curShowDeck = Instantiate(showDeck, transform.parent);
        }
    }
}