using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;

    public void SetDayText(string text)
    {
        dayText.text = text;
    }
}
