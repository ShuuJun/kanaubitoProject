using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Square : MonoBehaviour
{
    private Vector3 OriginPosition = new Vector3(-4f, 3f, 0f);
    private Vector3 TargetPosition1 = new Vector3(4f, 3f, 0f);
    private Vector3 TargetPosition2 = new Vector3(4f, -3f, 0f);
    private Vector3 TargetPosition3 = new Vector3(-4f, -3f, 0f);

    private float timeToMove = 1f;
    private float timeElapsed = 0f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = OriginPosition;
    }

    private void OnEnable()
    {
        TimeManager.OnMinuteChanged += TimeCheck;
    }

    private void OnDisable()
    {
        TimeManager.OnMinuteChanged -= TimeCheck;
    }

    private void TimeCheck()
    {
        Vector3 currentPos = transform.position;

        if (TimeManager.Minute == 00)
        {
            StartCoroutine(Move(currentPos, OriginPosition));
        }
        else if (TimeManager.Minute == 15)
        {
            StartCoroutine(Move(currentPos, TargetPosition1));
        }
        else if (TimeManager.Minute == 30)
        {
            StartCoroutine(Move(currentPos, TargetPosition2)); 
        }
        else if (TimeManager.Minute == 45)
        {
            StartCoroutine(Move(currentPos, TargetPosition3));
        }

    }

    private IEnumerator Move(Vector3 currentPos, Vector3 targetPos)
    {
        timeElapsed = 0f;
        while (timeElapsed < timeToMove)
        {
            transform.position = Vector3.Lerp(currentPos, targetPos, timeElapsed / timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
    }
}
