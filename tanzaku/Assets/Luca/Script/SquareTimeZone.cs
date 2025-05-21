using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareTimeZone : MonoBehaviour
{
    private Vector3 morningPosition = new Vector3(-5.3f, -2f, 0f);
    private Vector3 AfternoonPosition = new Vector3(0f, -2f, 0f);
    private Vector3 EveningPosition = new Vector3(5.3f, -2f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = morningPosition;
    }

    private void OnEnable()
    {
        TimeZoneTestSceneManager.TimeChange += TimeCheck;
    }

    private void OnDisable()
    {
        TimeZoneTestSceneManager.TimeChange -= TimeCheck;
    }


    private void TimeCheck()
    {
        if (TimeZoneTestSceneManager.timeZone == "Morning")
        {
            StartCoroutine(move(morningPosition));
        }
        else if(TimeZoneTestSceneManager.timeZone == "Afternoon")
        {
            StartCoroutine(move(AfternoonPosition));
        }
        else if (TimeZoneTestSceneManager.timeZone == "Evening")
        {
            StartCoroutine(move(EveningPosition));
        }
    }

    private IEnumerator move(Vector3 targetPos)
    {
        transform.position = targetPos;
        yield return null;
    }
}
