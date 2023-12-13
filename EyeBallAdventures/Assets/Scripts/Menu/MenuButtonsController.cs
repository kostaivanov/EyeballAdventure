 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuButtonsController : MonoBehaviour
{
    private const float loadingSceneTime = 0.6f;
    private const int initialFlagCounts = 2;
    private const int finalSceneIndex = 12;
    private FinishSceneController finishSceneController;

    //[SerializeField] private Button retryButton;

    [SerializeField] private Button playButtonMainMenu, playButtonFinish, homeButtonCongratzScene;

    [SerializeField] private ToggleGroup menuToggleGroup;
    [SerializeField] private TextMeshProUGUI timerCountTextInGame;

    [SerializeField] private GameObject gameStars;
    [SerializeField] private GameObject levelButtons;
    [SerializeField] private GameObject instructionsMenu, finishScene, inGameUIScene, adMobManager;
    //[SerializeField] private GameObject loadingScene;

    [SerializeField] private GameObject playerFlagCount;

    private TextMeshProUGUI playerFlagCountText;
    [SerializeField] private TextMeshProUGUI timerUIInGame;

    private MenuToggleGroup myMenuToggleGroup;
    private CanvasManager canvasManager;
    [SerializeField] private TextMeshProUGUI playerLivesCountText;
    private GameObject player;
    private AsyncOperation asyncLoadLevel;
    private bool isCoroutineExecuting = false;
    private int currentSceneIndex;
    private FinishSceneSounds finishSceneSound;
    private ResetTimer resetTimer;
    private AdMobBannersController adMobBannersController;
    private void Awake()
    {
        //homeButtonFinalScene.gameObject.SetActive(false);
    }

    private void Start()
    {
        finishSceneController = GetComponent<FinishSceneController>();
        adMobBannersController = adMobManager.GetComponent<AdMobBannersController>();
        myMenuToggleGroup = menuToggleGroup.GetComponentInChildren<MenuToggleGroup>();
        playButtonMainMenu.interactable = false;
        playButtonMainMenu.onClick.AddListener(OnButtonClicked);
        playButtonFinish.onClick.AddListener(LoadNextLevel);
        canvasManager = CanvasManager.GetInstance();
        //loadingScene.SetActive(false);
        //this.playerLivesCountText = GameObject.FindGameObjectWithTag("PlayerLives").GetComponent<TextMeshProUGUI>();
        playerFlagCountText = playerFlagCount.GetComponent<TextMeshProUGUI>();
        finishSceneSound = finishScene.GetComponent<FinishSceneSounds>();

        resetTimer = new ResetTimer();
    }

    public void ActivatePlayButton(bool value)
    {
        playButtonMainMenu.interactable = value;

        if (menuToggleGroup.AnyTogglesOn())
        {
            //Debug.Log(menuToggleGroup.ActiveToggles().FirstOrDefault().name);
            //Debug.Log(myMenuToggleGroup.SelectedLevel);
        }

    }
    internal void LoadNextLevel()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //asyncLoadLevel = SceneManager.LoadSceneAsync(currentSceneIndex + 1);
        PermanentFunctions.instance.remainingLives = PermanentFunctions.instance.InitialLivesCount;

        PermanentFunctions.instance.flagCounts = initialFlagCounts;
        playerFlagCountText.text = PermanentFunctions.instance.flagCounts.ToString();
        PermanentFunctions.instance.collectedCoinsPerLvl = 0;
        PermanentFunctions.instance.dropsCollectedPerLvl = 0;
        PermanentFunctions.instance.destroyedBoxesPerLvl = 0;

        finishSceneController.dropsAreCounted = false;
        finishSceneController.boxesAreCounted = false;
        finishSceneController.coinsAreCounted = false;

        finishSceneController.currentBoxNumber = 0;
        finishSceneController.currentCoinNumber = 0;
        finishSceneController.currentDropNumber = 0;

        resetTimer.ResetTime(this.gameObject);
        timerUIInGame.enabled = true;

        StartCoroutine(LoadingScene(currentSceneIndex + 1));
    }

    //private void ResetInstructions()
    //{
    //    InstructionsController instructions = instructionsMenu.GetComponentInParent<InstructionsController>();
    //    instructions.ResetInstructions();
    //}

    private void OnButtonClicked()
    {
        if (playButtonMainMenu.interactable == true)
        {
            menuToggleGroup.SetAllTogglesOff();
            timerCountTextInGame.enabled = true;
            finishSceneSound.wasPlayed = false;
            //ResetInstructions();
           
            //canvasManager.SwitchCanvas(CanvasType.LoadingScene);
            switch (myMenuToggleGroup.SelectedLevel_Index - 1)
            {
                case 0:
                    if (SceneManager.GetActiveScene().buildIndex != 0 || SceneManager.GetActiveScene().buildIndex == 0)
                    {
                        //asyncLoadLevel = SceneManager.LoadSceneAsync((int)Levels.Level_1);
                        StartCoroutine(LoadingScene((int)Levels.Level_1));
                    }
                   
                    break;
                case 1:
                    //asyncLoadLevel = SceneManager.LoadSceneAsync((int)Levels.Level_2);
                    StartCoroutine(LoadingScene((int)Levels.Level_2));                    
                    break;
                case 2:
                    //asyncLoadLevel = SceneManager.LoadSceneAsync((int)Levels.Level_3);
                    StartCoroutine(LoadingScene((int)Levels.Level_3));
                    break;
                case 3:
                    //asyncLoadLevel = SceneManager.LoadSceneAsync((int)Levels.Level_4);
                    StartCoroutine(LoadingScene((int)Levels.Level_4));
                    break;
                case 4:
                    //asyncLoadLevel = SceneManager.LoadSceneAsync((int)Levels.Level_5);
                    StartCoroutine(LoadingScene((int)Levels.Level_5));
                    break;
                case 5:
                    //asyncLoadLevel = SceneManager.LoadSceneAsync((int)Levels.Level_6);
                    StartCoroutine(LoadingScene((int)Levels.Level_6));
                    break;
                case 6:
                    //asyncLoadLevel = SceneManager.LoadSceneAsync((int)Levels.Level_7);
                    StartCoroutine(LoadingScene((int)Levels.Level_7));
                    break;
                case 7:
                    //asyncLoadLevel = SceneManager.LoadSceneAsync((int)Levels.Level_8);
                    StartCoroutine(LoadingScene((int)Levels.Level_8));
                    break;
                case 8:
                    //asyncLoadLevel = SceneManager.LoadSceneAsync((int)Levels.Level_9);
                    StartCoroutine(LoadingScene((int)Levels.Level_9));
                    break;
                case 9:
                    //asyncLoadLevel = SceneManager.LoadSceneAsync((int)Levels.Level_10);
                    //if(SceneManager.GetSceneByBuildIndex((int)Levels.Level_10).IsValid())
                    //{
                        StartCoroutine(LoadingScene((int)Levels.Level_10));
                    //}
                   
                    break;
                case 10:
                    //asyncLoadLevel = SceneManager.LoadSceneAsync((int)Levels.Level_11);
                    //if (SceneManager.GetSceneByBuildIndex((int)Levels.Level_11).IsValid())
                    //{
                        StartCoroutine(LoadingScene((int)Levels.Level_11));
                    //}
                    
                    break;
                case 11:
                    //asyncLoadLevel = SceneManager.LoadSceneAsync((int)Levels.Level_12);
                    //if (SceneManager.GetSceneByBuildIndex((int)Levels.Level_12).IsValid())
                    //{
                        StartCoroutine(LoadingScene((int)Levels.Level_12));
                    //}
                    break;
                //case 12:
                //    //asyncLoadLevel = SceneManager.LoadSceneAsync((int)Levels.Level_12);
                //    //if (SceneManager.GetSceneByBuildIndex((int)Levels.Level_12).IsValid())
                //    //{
                //    StartCoroutine(LoadingScene(finalSceneIndex));
                //    //}
                //    break;
                default:
                    break;
            }
        }
    }


    internal IEnumerator LoadingScene(int indexScene)
    {
        //Debug.Log(myMenuToggleGroup.SelectedLevel_Index - 1);
        Time.timeScale = 1.0f;
        if (isCoroutineExecuting)
            yield break;
        homeButtonCongratzScene.interactable = false;
        isCoroutineExecuting = true;
        gameStars.SetActive(false);
        levelButtons.SetActive(false);
        //SceneManager.LoadSceneAsync(indexScene);

        canvasManager.SwitchCanvas(CanvasType.LoadingScene);
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 0;
       
        //yield return new WaitForSeconds(loadingSceneTime);
        yield return SceneManager.LoadSceneAsync(indexScene);
        Time.timeScale = 0.0f;
        yield return new WaitForSecondsRealtime(3.5f);
        Time.timeScale = 1.0f;
        //adMobBannersController.DestroyBigBannerAd();
        canvasManager.SwitchCanvas(CanvasType.gameUI);
        if (indexScene > 11)
        {
            inGameUIScene.gameObject.SetActive(false);
            playerLivesCountText.enabled = false;
            canvasManager.SwitchCanvas(CanvasType.finalSceneButton);
            
        }
        if (SceneManager.GetActiveScene().buildIndex == 0 && instructionsMenu.GetComponentInParent<InstructionsController>().firstTimeActiveMenu == true)
        {
            Time.timeScale = 0.0f;
            instructionsMenu.SetActive(true);
        }
        if (indexScene < 12)
        {
            playerLivesCountText.enabled = true;
        }
        
        if (player != null)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
        }
        
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        PermanentFunctions.instance.GettingDamagedCount = 0;
        isCoroutineExecuting = false;
    }
}
