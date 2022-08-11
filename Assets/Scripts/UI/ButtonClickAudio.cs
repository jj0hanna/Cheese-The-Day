using Audio;
using UnityEngine;

public class ButtonClickAudio : MonoBehaviour
{
    public void PlayDownSound()
    {
        AudioManager.PlaySound("ClickDown");
    }

    public void PlayUpSound()
    {
        AudioManager.PlaySound("ClickUp");
    }
}
