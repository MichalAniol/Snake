﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }

    public void RepeatButton()
    {
        SceneManager.LoadScene(2);
    }
}
