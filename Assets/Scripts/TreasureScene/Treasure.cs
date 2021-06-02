using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Treasure : MonoBehaviour
{
    public List<Relic> relics;
    public Relic finalRelic;
    public RelicDisplay relicDisplay;
    public Button button;
    public AudioSource audioSource;
    
    //private int count = 0;
    public void Start()
    {
        foreach (var p in PlayerData.Instance.relic)
        {
            if (relics.Contains(p)) relics.Remove(p);
        }

        if (relics.Count == 0) relicDisplay.relicData = finalRelic;
        else relicDisplay.relicData = relics[Random.Range(0, relics.Count)];
        relicDisplay.Setup();
        audioSource.PlayOneShot(audioSource.clip);
    }


    public void GetTreasure()
    {
        if (relics.Count != 0)
        {
            relicDisplay.relicData.Add();
            PlayerData.Instance.relic.Add(relicDisplay.relicData);
            SceneManager.LoadScene("AdventureScene");
        }
        else
        {
          
        }
    }
}