using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    [Serializable]
    public struct TimeStructure
    {
        public int hour;
        public int minute;
    }

    [Header("Ingame Time")]
    [SerializeField] private TimeStructure dayStartTime;
    [SerializeField] private TimeStructure dayEndTime;
    
    [Header("Real Time")]
    [SerializeField] private int realTimeMinutes = 2;

    [SerializeField] private FloatVariable time;
    [SerializeField] private FloatVariable realTime;

    [SerializeField] private TimeWarning warningMessage;
    
    private float seconds = 0f;
    private float secondsEnd = 0f;
    private float stepSize;
    private float warningTime = 0f;

    private bool checkWarningTime = true;
    
    public event Action<float> OnTimeUpdated;
    public event Action OnTimeFinished;
    public UnityEvent OnTimeFinishedExtra;

    void Awake()
    {
        ConvertDayTimesToSeconds();
        CalculateStepSize();
        CalculateWarningTime();

        if (seconds > secondsEnd)
        {
            throw new Exception("Day end time is before day start time.");
        }
    }
 
    void Update()
    {
        seconds += Time.deltaTime * stepSize;
        OnTimeUpdated?.Invoke(seconds);

        if (seconds >= secondsEnd)
        {
            OnTimeFinished?.Invoke();
            OnTimeFinishedExtra?.Invoke();
        }

        if (checkWarningTime)
        {
            if (seconds >= warningTime)
            {
                AudioManager.PlaySound("WarningSound");
                warningMessage.ShowWarning();
                checkWarningTime = false;
            }
        }
    }
    
    public void SetEndDayStats()
    {
        time.SetValue(CalculateTimeSpent());
        realTime.SetValue(CalculateRealTimeSpent());
    }
    
    private float CalculateTimeSpent()
    {
        return seconds - (dayStartTime.hour * 60 + dayStartTime.minute);
    }

    private float CalculateRealTimeSpent()
    {
        return CalculateTimeSpent() / stepSize;
    }
    
    private void ConvertDayTimesToSeconds()
    {
        seconds = dayStartTime.hour * 60 + dayStartTime.minute;
        secondsEnd = dayEndTime.hour * 60 + dayEndTime.minute;
    }

    private void CalculateStepSize()
    {
        float diff = secondsEnd - seconds;
        float rtConverted = realTimeMinutes * 60;
        stepSize = diff / rtConverted;
    }

    private void CalculateWarningTime()
    {
        warningTime = 8f * 60f;
    }
}