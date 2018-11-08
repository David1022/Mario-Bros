﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour {

    private const string SCREEN_TO_OPEN = "StartScreen";

    public void LaunchMenuScreen()
    {
        SceneManager.LoadScene(SCREEN_TO_OPEN);
    }
}
