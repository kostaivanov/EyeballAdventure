using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class ButtonController : MonoBehaviour
{
    private const int initialFlagCounts = 2;

    //private LoadingSceneDelay loadingScene;

    //the canvas that we want to switch to when the button is clicked, will give us a drop down menu to pick desired canvas
    public ButtonType buttonType;

    private CanvasManager canvasManager;
    private Button menuButton;
    private GameObject player;

    [SerializeField] private GameObject playerLivesCount;
    private TextMeshProUGUI playerLivesCountText;
    [SerializeField] private GameObject playerFlagCount;
    private TextMeshProUGUI playerFlagCountText;

    [SerializeField] private GameObject canvas;
    private FinishSceneController finishScene;
    private FinishSceneSounds finishSceneSound;
    private TimeCounter timeCounter;
    [SerializeField] private TextMeshProUGUI timerUIInGame;
   
    [SerializeField]
    private GameObject gameStars, levelButtons;

    [SerializeField]
    private GameObject levelCompletedStars_1, levelCompletedStars_2, levelCompletedStars_3;

    //private MenuButtonsController menuButtonsController;
    private ResetTimer resetTimer;
    private void Start()
    {       
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
        canvasManager = CanvasManager.GetInstance();
        QualitySettings.vSyncCount = 0;
        this.playerLivesCountText = playerLivesCount.GetComponent<TextMeshProUGUI>();
        //this.canvas = GameObject.FindGameObjectWithTag("Canvas");
        this.finishScene = canvas.GetComponent<FinishSceneController>();
        this.timeCounter = canvas.GetComponent<TimeCounter>();
        finishSceneSound = canvas.GetComponentInChildren<FinishSceneSounds>();
        //this.timerUI = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>();

        playerFlagCountText = playerFlagCount.GetComponent<TextMeshProUGUI>();
        //menuButtonsController = GetComponentInParent<MenuButtonsController>();
        resetTimer = new ResetTimer();
    }

    private void OnButtonClicked()
    {
        switch (buttonType)
        {
            case ButtonType.Pause:
                player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    player.GetComponent<PlayerMovement>().enabled = false;
                }

                Time.timeScale = 0.0f;                              
                canvasManager.SwitchCanvas(CanvasType.pauseMenu);
                Application.targetFrameRate = 10;
                QualitySettings.vSyncCount = 0;
                playerLivesCountText.enabled = false;
                timerUIInGame.enabled = false;
                break;

            case ButtonType.Resume:
                Time.timeScale = 1.0f;
                player = GameObject.FindGameObjectWithTag("Player");

                if (player != null)
                {
                    player.GetComponent<PlayerMovement>().enabled = true;
                }                             
                canvasManager.SwitchCanvas(CanvasType.gameUI);
                Application.targetFrameRate = 60;
                QualitySettings.vSyncCount = 0;
                playerLivesCountText.enabled = true;
                timerUIInGame.enabled = true;
                break;

            case ButtonType.Retry:
                //Time.timeScale = 1.0f;

                levelCompletedStars_1.SetActive(false);
                levelCompletedStars_2.SetActive(false);
                levelCompletedStars_3.SetActive(false);
                this.finishScene.dropsAreCounted = false;
                PermanentFunctions.instance.flagCounts = initialFlagCounts;
                playerFlagCountText.text = PermanentFunctions.instance.flagCounts.ToString();

                //Disable some of the UI elements like coins,boxes drops in the finish scene
                FinishScene_DisableCollectable_UI_Elements();

                //ResetTimer();
                resetTimer.ResetTime(canvas);
                timerUIInGame.enabled = true;
                //timeCounter.timer.text = timeCounter.minutes.ToString("00") + ":" + timeCounter.seconds.ToString("00");

                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                playerLivesCountText.enabled = true;
                PermanentFunctions.instance.lastCheckPointPosition = PermanentFunctions.instance.startPosition;
                PermanentFunctions.instance.GettingDamagedCount = 0;
                finishSceneSound.wasPlayed = false;

                PemanentFunction_ResetCollectableElements();

                FinishScene_ResetUI_Elements_Numbers();

                //canvasManager.SwitchCanvas(CanvasType.LoadingScene);

                //canvasManager.SwitchCanvas(CanvasType.gameUI);
                //Application.targetFrameRate = 60;
                //QualitySettings.vSyncCount = 0;
                //StartCoroutine(loadingScene.LoadingScene(canvasManager, levelIndex));
                break;

            case ButtonType.Menu:
                levelCompletedStars_1.SetActive(false);
                levelCompletedStars_2.SetActive(false);
                levelCompletedStars_3.SetActive(false);
                this.finishScene.dropsAreCounted = false;

                //ResetTimer();
                resetTimer.ResetTime(canvas);

                //Disable some of the UI elements like coins,boxes drops in the finish scene
                FinishScene_DisableCollectable_UI_Elements();

                PemanentFunction_ResetCollectableElements();

                FinishScene_ResetUI_Elements_Numbers();

                PermanentFunctions.instance.remainingLives = PermanentFunctions.instance.InitialLivesCount;
                PermanentFunctions.instance.lastCheckPointPosition = PermanentFunctions.instance.startPosition;
                this.playerLivesCountText.text = PermanentFunctions.instance.remainingLives.ToString();

                PermanentFunctions.instance.flagCounts = initialFlagCounts;
                playerFlagCountText.text = PermanentFunctions.instance.flagCounts.ToString();

                Application.targetFrameRate = 10;

                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                canvasManager.SwitchCanvas(CanvasType.MainMenu);
                gameStars.SetActive(true);
                levelButtons.SetActive(true);
                playerLivesCountText.enabled = false;
                Time.timeScale = 0.0f;
                QualitySettings.vSyncCount = 0;
                timerUIInGame.enabled = true;

                StopAllCoroutines();
                break;

            case ButtonType.Quit:
                Debug.Log("Application Quit!");
                Application.Quit();
                //EditorApplication.isPlaying = false;
                break;
        }

    }

    private static void PemanentFunction_ResetCollectableElements()
    {
        PermanentFunctions.instance.collectedCoinsPerLvl = 0;
        PermanentFunctions.instance.destroyedBoxesPerLvl = 0;
        PermanentFunctions.instance.dropsCollectedPerLvl = 0;
    }

    private void FinishScene_ResetUI_Elements_Numbers()
    {
        finishScene.currentCoinNumber = 0;
        finishScene.currentBoxNumber = 0;
        finishScene.currentDropNumber = 0;
    }

    private void FinishScene_DisableCollectable_UI_Elements()
    {
       
        finishScene.coinsAreCounted = false;
        finishScene.boxesAreCounted = false;
        finishScene.collectedCoinsCountText.enabled = false;
        finishScene.coinImage.enabled = false;
        finishScene.destroyedBoxesCountText.enabled = false;
        finishScene.boxImage.enabled = false;
        finishScene.pickedDropsCountText.enabled = false;
        finishScene.dropImage.enabled = false;
    }

    //private void ResetTimer()
    //{
    //    this.timeCounter.time = 0;
    //    this.timeCounter.seconds = 0;
    //    this.timeCounter.minutes = 0;
    //    timeCounter.timer.text = timeCounter.minutes.ToString("00") + ":" + timeCounter.seconds.ToString("00");
    //}
}
