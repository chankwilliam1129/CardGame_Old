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

    public float posXVariation;


    public BattleEvent()
    {
        BattleEventManager.Instance?.Add(this);
    }

    private void Start()
    {
        gameObject.SetActive(false);
        timeCounter = 0.0f;
        BattleEventManager.Instance?.Execute();

        if(from != null)
        {
            transform.position = from.position;
        }
        if(target != null)
        {
            transform.LookAt(target, Vector3.forward);
        }

        if (posXVariation != 0.0f) posXVariation = Random.Range(-posXVariation, posXVariation);

    }

    private void Update()
    {
        if (autoDestroy)
        {
            timeCounter += Time.deltaTime;

            if (autoMovement)
            {
                float c = curve.Evaluate(timeCounter / destroyTime);
                Vector3 pos = Vector3.Lerp(from.position, target.position, c);
                pos.x += (0.5f - Mathf.Abs(c - 0.5f)) * posXVariation;

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