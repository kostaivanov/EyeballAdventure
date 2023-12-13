using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSound : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen;
    private bool gameOverSoundRestarted;
    private GameOverScreenSound gameoverSoundObj;
    private void Start()
    {
        gameoverSoundObj = gameOverScreen.GetComponent<GameOverScreenSound>();
    }

    private void Update()
    {
        if (gameOverScreen.activeSelf.Equals(false) && gameoverSoundObj.wasPlayed.Equals(true))
        {            
            gameoverSoundObj.wasPlayed = false;
        }
    }
}
