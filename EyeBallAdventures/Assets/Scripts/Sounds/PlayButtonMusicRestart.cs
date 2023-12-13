using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonMusicRestart : MonoBehaviour
{
    internal bool restartMusicClicked = false;

    public void RestartMusic()
    {
        restartMusicClicked = true;
    }
}
