using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCardElement : MonoBehaviour
{
    private HandCardLayoutGroup layoutGroup;

    public float flexibleWidth = 1.0f;
    public AnimationCurve curve;

    public Vector3 curPosition;
    public Vector3 targetPosition;
    public float animationTimer;

    public bool isActivity;
    private bool isMoving;

    private void Start()
    {
        isMoving = false;
        layoutGroup = transform.parent.GetComponent<HandCardLayoutGroup>();
        if (layoutGroup != null)
        {
            layoutGroup.elements.Add(this);
            layoutGroup.ElementUpdate();
        }
        else
        {
            Debug.Log("HandCardLayoutGroup NotFound");
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            if (animationTimer > 1.0f)
            {
                isMoving = false;
                animationTimer = 1.0f;
            }

            float c = curve.Evaluate(animationTimer);
            Vector3 pos = curPosition + (targetPosition - curPosition) * c;
            transform.position = pos;
            animationTimer += Time.deltaTime * layoutGroup.speed;
        }
    }

    private void OnDestroy()
    {
        if (layoutGroup != null)
        {
            layoutGroup.elements.Remove(this);
            layoutGroup.ElementUpdate();
        }
    }

    public void MovingTo(Vector3 pos)
    {
        isMoving = true;
        curPosition = transform.position;
        targetPosition = pos;
        animationTimer = 0.0f;
    }

    public void SetFlexibleWidth(float width)
    {
        flexibleWidth = width;
        layoutGroup?.ElementUpdate();
    }
}