using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneScript : MonoBehaviour
{
    public void Press()
    {
        SceneManager.LoadScene("MAIN"); //I feel sticky using strings
    }
}
