using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotInTimeForWorkText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NotINtimeForWorkText;
    
    public void ShowNotIntime()
    {
        NotINtimeForWorkText.gameObject.SetActive(true);
        NotINtimeForWorkText.text = "You did not make it in time to work!";
    }
    
}
