using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    private Clock clock;
    
    private void Awake()
    {
        clock = GetComponent<Clock>();
        clock.OnTimeUpdated += UpdateTime;
        clock.OnTimeFinished += ShowTimesUp;
    }

    private void UpdateTime(float newTime)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(newTime);
        timeText.text = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
        // Maybe check up on .NET version.
        //timeText.text = TimeSpan.FromSeconds(newTime).ToString("mm:ss");
    }

    private void ShowTimesUp()
    {
        timeText.text = "Time's up.";
        clock.OnTimeUpdated -= UpdateTime;
    }
}
