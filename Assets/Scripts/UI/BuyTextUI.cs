using TMPro;
using UnityEngine;

namespace UI
{
    public class BuyTextUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buyText;

        public void SetbuyCheeseText(string text)
        {
            buyText.text = text;
        }

        public void SetActive()
        {
        }
    }
}