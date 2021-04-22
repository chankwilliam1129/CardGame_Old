using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSpaceDisplay : MonoBehaviour
{
    public CardDisplay card;
    public PowerDisplay powerDisplay;
    public Image powerSpaceIcon;

    public List<Image> powerList;

    private void Start()
    {
        for (int i = 0; i < card.data.powerSpace; i++)
        {
            Vector3 pos = transform.position;
            pos.x += (card.data.powerSpace * -10f * card.transform.lossyScale.x) + (i + 0.5f) * 20f * card.transform.lossyScale.x;
            powerList.Add(Instantiate(powerSpaceIcon, pos, Quaternion.identity, transform));
        }
    }

    public void PowerDisplayUpdate()
    {
        int empty = CardEffectExecutor.Instance.totalEmptyPower;
        int normal = empty + CardEffectExecutor.Instance.totalNormalPower;
        int broken = normal + CardEffectExecutor.Instance.totalBrokenPower;

        if (broken <= card.data.powerSpace && !card.GetComponent<Animator>().GetBool("isMod"))
        {
            for (int i = 0; i < card.data.powerSpace; i++)
            {
                if (i < empty) powerList[i].sprite = powerDisplay.emptyPowerIcon.sprite;
                else if (i < normal) powerList[i].sprite = powerDisplay.normalPowerIcon.sprite;
                else if (i < broken) powerList[i].sprite = powerDisplay.brokenPowerIcon.sprite;
                else powerList[i].sprite = powerSpaceIcon.sprite;
            }
        }
        else
        {
            foreach (var p in powerList)
            {
                p.sprite = powerSpaceIcon.sprite;
            }
        }
    }
}