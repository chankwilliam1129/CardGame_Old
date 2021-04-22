using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvent : MonoBehaviour
{
    public bool autoDestroy = false;
    public float destroyTime;
    public float timeCounter;

    public bool autoMovement = false;
    public AnimationCurve curve;
    public Transform from;
    public Transform target;

    public BattleEvent()
    {
        BattleEventManager.Instance?.Add(this);
    }

    private void Start()
    {
        gameObject.SetActive(false);
        timeCounter = 0.0f;
        BattleEventManager.Instance?.Execute();
    }

    private void Update()
    {
        if (autoDestroy)
        {
            timeCounter += Time.deltaTime;

            if (autoMovement)
            {
                float c = curve.Evaluate(timeCounter / destroyTime);
                Vector3 pos = from.position + (target.position - from.position) * c;
                transform.position = pos;
            }

            if (timeCounter > destroyTime) Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        BattleEventManager.Instance?.Remove(this);
        BattleEventManager.Instance?.Execute();
    }
}