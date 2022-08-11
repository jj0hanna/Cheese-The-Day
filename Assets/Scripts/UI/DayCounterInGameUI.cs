using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DayCounterInGameUI : MonoBehaviour
    {
        private TextMeshProUGUI dayCounterText;
        [SerializeField] private IntVariable dayCount;

        private void Awake()
        {
            dayCounterText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            Debug.Log("Enabled.");
            UpdateDayCounterText();
        }

        private void UpdateDayCounterText()
        {
            dayCounterText.text = $"Day {dayCount.Value}/5";
        }
    }
}