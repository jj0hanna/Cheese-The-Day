using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;


public class RandomSoundPlayer : MonoBehaviour
{
    [SerializeField] private string[] sounds;

    private int lastRandom = 0;

    public void PlayRandomSound()
    {
        int random = Random.Range(0, sounds.Length);
        while (random == lastRandom)
        {
            random = Random.Range(0, sounds.Length);
        }

        lastRandom = random;
        AudioManager.PlaySound(sounds[random]);
    }
}
