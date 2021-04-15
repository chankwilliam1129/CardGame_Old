using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvent : MonoBehaviour
{
    public int sortOrder;
    public bool autoDestroy = false;
    public float destroyTime;

    public void AddEvent()
    {
        BattleEventManager.Instance.Add(this);
        gameObject.SetActive(false);
    }
    
    void Start()
    {
    }
    void Update()
    {
        if(autoDestroy)
        {
            destroyTime -= Time.deltaTime;
            if (destroyTime < 0.0f) Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        BattleEventManager.Instance.Remove(this);
    }
}
