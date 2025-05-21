using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static int Minute { get; private set; }
    public static int Hour { get; private set; }

    [SerializeField] private float minuteToRealTime = 0.03f;
    private float timer = 0f;

    void Start()
    {
        Minute = 0;
        Hour = 0;
        timer = 0f; // Start at 0 so first press is instant
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                AdvanceTime();
                timer = minuteToRealTime;
            }
        }
        else
        {
            timer = 0f; // Reset so next press is instant
        }
    }

    private void AdvanceTime()
    {
        Minute++;
        OnMinuteChanged?.Invoke();

        if (Minute >= 60)
        {
            Hour++;
            Minute = 0;
            OnHourChanged?.Invoke();
        }
    }
}
