using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEndGame : MonoBehaviour
{
    internal void Pause()
    {
        Time.timeScale = 0.0f;
        Application.targetFrameRate = 10;
        QualitySettings.vSyncCount = 0;
    }
}
