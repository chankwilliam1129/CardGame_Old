using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvent : MonoBehaviour
{
    public bool autoDestroy = false;
    public float destroyTime;

    public BattleEvent()
    {
        BattleEventManager.Instance?.Add(this);
    }

    void Start()
    {
        gameObject.SetActive(false);
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
