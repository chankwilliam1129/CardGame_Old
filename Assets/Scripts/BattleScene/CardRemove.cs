using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRemove : MonoBehaviour
{
    public CardDisplay cardDisplay;
    public float TimeCounter = 0.0f;

    private Vector3 curPosition;
    private Transform targetPosition;
    private Quaternion targetRotation;

    public bool isToMainDeck;

    private void Start()
    {
        curPosition = transform.position;

        if (isToMainDeck)
        {
            targetPosition = MainDeckUI.Instance.transform;
            targetRotation = Quaternion.Euler(0.0f, 0.0f, 125f);
        }
        else
        {
            switch (cardDisplay.data.removeType)
            {
                case BattleDeckManager.RemoveType.Discard:
                    targetPosition = DiscardPileUI.Instance.transform;
                    targetRotation = Quaternion.Euler(0.0f, 0.0f, 125f);
                    break;

                case BattleDeckManager.RemoveType.Exhausted:
                    targetPosition = transform;
                    break;
            }
        }
    }

    private void Update()
    {
        transform.position = Vector3.Slerp(curPosition, targetPosition.position, TimeCounter);
        transform.rotation = Quaternion.Slerp(Quaternion.identity, targetRotation, TimeCounter);

        if (TimeCounter >= 1.0) Destroy(gameObject);
    }

    public void SetUp(CardDisplay card)
    {
        transform.position = card.transform.position;
        transform.rotation = card.transform.rotation;
        cardDisplay.data = card.data;
        cardDisplay.SetUp();
    }
}