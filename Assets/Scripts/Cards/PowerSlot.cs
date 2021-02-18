using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSlot : MonoBehaviour
{

    public CardSlot cardSlot;

    public List<Image> slots;
    public Sprite powerSlotImage;
    public Sprite emptyPowerImage;
    public Sprite normalPowerImage;
    public Sprite brokenPowerImage;

    void Start()
    {
        cardSlot.OnSlotChange += Slot_OnSlotChange;
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    private void Slot_OnSlotChange(object sender, System.EventArgs e)
    {
        if (cardSlot.card != null)
        {
            gameObject.SetActive(true);

            int maxPower = cardSlot.card.card.powerSpace;
            int totalEmptyPower = 0;
            int totalNormalPower = 0;
            int totalBrokenPower = 0;

            if (cardSlot.power.Count != 0)
            {
                foreach (CardDisplay c in cardSlot.power)
                {
                    totalEmptyPower += c.card.emptyPower;
                    totalNormalPower += c.card.normalPower;
                    totalBrokenPower += c.card.brokenPower;
                }
            }

            for (int i = 0; i < 6; i++)
            {
                if (i > maxPower - 1) slots[i].gameObject.SetActive(false);
                else
                {
                    slots[i].gameObject.SetActive(true);
                    if (i < totalNormalPower) slots[i].sprite = normalPowerImage;
                    else if (i < totalNormalPower + totalEmptyPower) slots[i].sprite = emptyPowerImage;
                    else if (i < totalNormalPower + totalEmptyPower + totalBrokenPower) slots[i].sprite = brokenPowerImage;
                    else slots[i].sprite = powerSlotImage;
                }
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
