using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : CardDisplayOnlyGroup
{
    public CardDatabase cardDatabase;
    public CardDisplay[] sellCard = new CardDisplay[5];
    public GameObject soldout;
    public CardRemove cardRemove;
    public AudioSource audioSource;
    public List<AudioClip> sounds = new List<AudioClip>();

    public static Store Instance { get; private set; }

    private Store()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            sellCard[i].data = cardDatabase.cardList[Random.Range(0, cardDatabase.cardList.Count)].battleData;
            sellCard[i].SetUp();
            sellCard[i].GetComponent<StoreCardDisplay>().priceText.text = "" + sellCard[i].data.preset.price;
            if (sellCard[i].data.preset.price > PlayerData.Instance.coin)
            {
                sellCard[i].GetComponent<StoreCardDisplay>().priceText.color = new Color(1.0f, 0.0f, 0.3f, 1.0f);
            }
        }
    }

    public override void OnPointEnter(CardDisplay card)
    {
        audioSource.PlayOneShot(sounds[2]);
        card.GetComponent<Animator>().SetBool("isTouch", true);
    }

    public override void OnPointExit(CardDisplay card)
    {
        card.GetComponent<Animator>().SetBool("isTouch", false);
    }

    public override void OnClick(CardDisplay card)
    {
        if (!card.GetComponent<StoreCardDisplay>().isSet) return;
        if (PlayerData.Instance.coin >= card.data.preset.price)
        {
            PlayerData.Instance.coin -= card.data.preset.price;

            for (int i = 0; i < 5; i++)
            {
                if (sellCard[i].data.preset.price > PlayerData.Instance.coin)
                {
                    sellCard[i].GetComponent<StoreCardDisplay>().priceText.color = new Color(1.0f, 0.0f, 0.3f, 1.0f);
                }
            }
            BuyCard(card);
            Instantiate(cardRemove, card.transform.position, card.transform.rotation, transform).SetUp(card);
            Instantiate(soldout, card.transform.position, soldout.transform.rotation, transform);
            card.gameObject.SetActive(false);

            audioSource.PlayOneShot(sounds[0]);
        }
        else
        {
            TextManager.Instance.notEnoughCoinText.gameObject.SetActive(true);
            audioSource.PlayOneShot(sounds[1]);
        }
    }

    private void BuyCard(CardDisplay card)
    {
        PlayerData.Instance.deck.Add(card.data);
    }
}