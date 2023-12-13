using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

internal class PlayerLives : MonoBehaviour
{
    private bool isAlive;

    private GameObject player;

    private TextMeshProUGUI playerLivesCountText;
    private CanvasManager canvasManager;
    private TextMeshProUGUI timer;

    // Start is called before the first frame update
    private void Start()
    {
        canvasManager = CanvasManager.GetInstance();

        this.player = GameObject.FindGameObjectWithTag("Player");

        this.playerLivesCountText = GameObject.FindGameObjectWithTag("PlayerLives").GetComponent<TextMeshProUGUI>();

        this.timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>();
        this.playerLivesCountText.text = PermanentFunctions.instance.remainingLives.ToString();
        this.isAlive = true;

        //homeButtonPause = canvasManager.homeButtonPause.GetComponent<HomeButtonHandler>();
        //homeButtonGO = canvasManager.homeButtonGO.GetComponent<HomeButtonHandler>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (this.player == null && this.isAlive)
        {
            this.isAlive = false;

            if (!isAlive)
            {
                PermanentFunctions.instance.remainingLives--;

            }

            if (PermanentFunctions.instance.remainingLives < 0)
            {
                EndGame();

                PermanentFunctions.instance.remainingLives = PermanentFunctions.instance.InitialLivesCount;
                PermanentFunctions.instance.flagCounts = 2;
            }
        }
    }

    internal void EndGame()
    {
        this.playerLivesCountText.enabled = false;
        this.timer.enabled = false;

        canvasManager.SwitchCanvas(CanvasType.GameOverMenu);       
    }

}
