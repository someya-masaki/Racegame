﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryManager : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
