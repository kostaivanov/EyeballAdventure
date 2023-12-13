using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Load2ndLevel : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private CanvasManager canvasManager;
    private TextMeshProUGUI playerLivesCountText;
    //private int currentSceneIndex;
    //[SerializeField] private Button playButton;
    [SerializeField] private GameObject player;
    //private CashCollector playerCash;
    private int currentSceneIndex;
    private void OnTriggerEnter2D(Collider2D playerObject)
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        this.playerLivesCountText = GameObject.FindGameObjectWithTag("PlayerLives").GetComponent<TextMeshProUGUI>();
        canvasManager = CanvasManager.GetInstance();
        //playButton.onClick.AddListener(OnButtonClicked);

        if (playerObject.gameObject.CompareTag("Player"))
        {
            //playerCash = this.player.GetComponent<CashCollector>();
            PermanentFunctions.instance.collectedCoinsPerLvl += PermanentFunctions.instance.collectedCoinsTemp;
            PermanentFunctions.instance.destroyedBoxesPerLvl += PermanentFunctions.instance.destroyedBoxesTemp;
            PermanentFunctions.instance.dropsCollectedPerLvl += PermanentFunctions.instance.dropsCollectedTemp;

            if (PermanentFunctions.instance.flagCounts == 0)
            {
                PermanentFunctions.instance.collectedCoinsPerLvl -= 20;
            }

            if (PermanentFunctions.instance.flagCounts == 1)
            {
                PermanentFunctions.instance.collectedCoinsPerLvl -= 10;
            }

            canvasManager.SwitchCanvas(CanvasType.FinishScene);
            Time.timeScale = 0.0f;
            playerLivesCountText.enabled = false;

            //SceneManager.LoadScene(sceneName);
            PermanentFunctions.instance.lastCheckPointPosition = PermanentFunctions.instance.startPosition;

        }

        
    }
}
