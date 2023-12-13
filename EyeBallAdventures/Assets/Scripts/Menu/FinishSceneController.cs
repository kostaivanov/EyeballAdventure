using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class FinishSceneController : MonoBehaviour
{
    #region constants
    private const int pointsFromCoins = 20;
    private const int pointsFromBoxes = 10;
    private const int pointsFromDrops = 30;
    private const int bonusPointNotHit = 150;
    private const float countingItemsSpeed = 0.025f;
    private const int finalLevelIndex = 11;
    #endregion

    #region Lists with collectable items
    //internal List<GameObject> allCoins = new List<GameObject>();
    //internal List<GameObject> allBoxes = new List<GameObject>();
    //internal List<GameObject> allDrops = new List<GameObject>();
    #endregion

    #region UI Collection text items from finish scene
    //[SerializeField] internal TextMeshProUGUI allCoinsCountText;
    [SerializeField] internal TextMeshProUGUI collectedCoinsCountText;
    //[SerializeField] internal TextMeshProUGUI coinSlash;
    [SerializeField] internal Image coinImage;

    //[SerializeField] internal TextMeshProUGUI allBoxesCountText;
    [SerializeField] internal TextMeshProUGUI destroyedBoxesCountText;
    //[SerializeField] internal TextMeshProUGUI boxSlash;
    [SerializeField] internal Image boxImage;

    //[SerializeField] internal TextMeshProUGUI allDropsCountText;
    [SerializeField] internal TextMeshProUGUI pickedDropsCountText;
    //[SerializeField] internal TextMeshProUGUI dropSlash;
    [SerializeField] internal Image dropImage;

    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private TextMeshProUGUI bonusScoreText;

    [SerializeField] private TextMeshProUGUI timerCountText;
    [SerializeField] private TextMeshProUGUI timerCountTextInGame;
    #endregion

    [SerializeField] private GameObject finishScene;

    [SerializeField] private Button playButton, retryButton, homeButton;

    //[SerializeField] private GameObject confetti;
    //private GameObject clone;

    internal int TotalScore { get; private set; }
    internal int currentCoinNumber = 0;
    internal int currentBoxNumber = 0;
    internal int currentDropNumber = 0;
    private float timer;
    internal bool coinsAreCounted = false;
    internal bool boxesAreCounted = false;
    internal bool dropsAreCounted = false;
    private Vector3 scaleChange, positionChange;
    internal TimeCounter timeCounter;
    internal bool isTotalScoreCalculated { get; private set; }

    //private FinalSceneController finalSceneController_Component;

    private void Awake()
    {
        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
        positionChange = new Vector3(0.0f, -0.005f, 0.0f);

        //allCoinsCountText.enabled = false;
        collectedCoinsCountText.enabled = false;
        //coinSlash.enabled = false;
        coinImage.enabled = false;

        //allBoxesCountText.enabled = false;
        destroyedBoxesCountText.enabled = false;
        //boxSlash.enabled = false;
        boxImage.enabled = false;

        //allDropsCountText.enabled = false;
        pickedDropsCountText.enabled = false;
        //dropSlash.enabled = false;
        dropImage.enabled = false;

        
    }

    // Start is called before the first frame update
    private void Start()
    {
        isTotalScoreCalculated = false;
        //allCoins.AddRange(GameObject.FindGameObjectsWithTag("Money"));
        //allBoxes.AddRange(GameObject.FindGameObjectsWithTag("Box"));
        //allDrops.AddRange(GameObject.FindGameObjectsWithTag("Collectable"));
        //this.allCoinsCountText.text = allCoins.Count.ToString();
        //this.allBoxesCountText.text = allBoxes.Count.ToString();
        //this.allDropsCountText.text = allDrops.Count.ToString();       

        timeCounter = GetComponent<TimeCounter>();
        //finalSceneController_Component = GetComponent<FinalSceneController>();
        //finalSceneController_Component.enabled = false;

        playButton.interactable = false;
        retryButton.interactable = false;
        homeButton.interactable = false;
        currentCoinNumber = 0;
        currentBoxNumber = 0;
        currentDropNumber = 0;
       

        coinsAreCounted = false;
        dropsAreCounted = false;
        boxesAreCounted = false;
    }
    private void Update()
    {
        if (finishScene.activeSelf == true)
        {
            //CheckIfFinalSceneLevel();
            if (dropsAreCounted != true)
            {              
                retryButton.interactable = false;
                homeButton.interactable = false;  
                playButton.interactable = false;
            }

            //this.pickedDropsCountText.text = PermanentFunctions.instance.dropsCollectedTemp.ToString();
            //this.destroyedBoxesCountText.text = PermanentFunctions.instance.destroyedBoxesTemp.ToString();
            //this.collectedCoinsCountText.text = PermanentFunctions.instance.collectedCoinsTemp.ToString();

            this.pickedDropsCountText.text = PermanentFunctions.instance.dropsCollectedPerLvl.ToString();
            this.destroyedBoxesCountText.text = PermanentFunctions.instance.destroyedBoxesPerLvl.ToString();
            this.collectedCoinsCountText.text = PermanentFunctions.instance.collectedCoinsPerLvl.ToString();

            Application.targetFrameRate = 30;
            //clone = Instantiate(confetti, this.finishScene.transform.position, Quaternion.identity);
            //allCoinsCountText.enabled = true;
            collectedCoinsCountText.enabled = true;
            //coinSlash.enabled = true;
            coinImage.enabled = true;

            timerCountText.text = timeCounter.timer.text;
            timerCountTextInGame.enabled = false;
            //this.destroyedBoxesCountText.text = PermanentFunctions.instance.destroyedBoxesPerLvl.ToString();

            //this.pickedDropsCountText.text = PermanentFunctions.instance.dropsCollectedPerLvl.ToString();

            TotalScore = ((PermanentFunctions.instance.collectedCoinsPerLvl * pointsFromCoins) +
               (PermanentFunctions.instance.destroyedBoxesPerLvl * pointsFromBoxes) +
               (PermanentFunctions.instance.dropsCollectedPerLvl * pointsFromDrops)) + PermanentFunctions.instance.lifePickUpPoints;
            
            if (PermanentFunctions.instance.GettingDamagedCount == 0)
            {
                this.bonusScoreText.text = bonusPointNotHit.ToString();
                TotalScore += bonusPointNotHit;
            }
            else
            {
                this.bonusScoreText.text = 0.ToString();
            }

            this.totalScoreText.text = TotalScore.ToString();

            if (currentCoinNumber < PermanentFunctions.instance.collectedCoinsPerLvl)
            {
                currentCoinNumber = CountAndScaleUI(currentCoinNumber, coinImage);
                collectedCoinsCountText.text = currentCoinNumber.ToString();
            }

            if (currentCoinNumber == PermanentFunctions.instance.collectedCoinsPerLvl)
            {
                EqualizeScaleImageUI(coinImage);
                if (coinImage.transform.localScale == new Vector3(1,1,1))
                {
                    coinsAreCounted = true;
                }

            }

            if (coinsAreCounted == true)
            {
                //allBoxesCountText.enabled = true;
                destroyedBoxesCountText.enabled = true;
                //boxSlash.enabled = true;
                boxImage.enabled = true;

                if (currentBoxNumber < PermanentFunctions.instance.destroyedBoxesPerLvl)
                {
                    currentBoxNumber = CountAndScaleUI(currentBoxNumber, boxImage);
                    destroyedBoxesCountText.text = currentBoxNumber.ToString();
                }
               
                if (currentBoxNumber == PermanentFunctions.instance.destroyedBoxesPerLvl)
                {
                    EqualizeScaleImageUI(boxImage);
                    if (boxImage.transform.localScale == new Vector3(1, 1, 1))
                    {
                        boxesAreCounted = true;
                    }
                }
            }
            else
            {
                destroyedBoxesCountText.enabled = false;
                //boxSlash.enabled = false;
                boxImage.enabled = false;

                //allDropsCountText.enabled = false;
                pickedDropsCountText.enabled = false;
                //dropSlash.enabled = false;
                dropImage.enabled = false;
            }

            if (boxesAreCounted == true)
            {
                //allDropsCountText.enabled = true;
                pickedDropsCountText.enabled = true;
                //dropSlash.enabled = true;
                dropImage.enabled = true;

                if (currentDropNumber < PermanentFunctions.instance.dropsCollectedPerLvl)
                {
                    currentDropNumber = CountAndScaleUI(currentDropNumber, dropImage);
                    pickedDropsCountText.text = currentDropNumber.ToString();
                }

                if (currentDropNumber == PermanentFunctions.instance.dropsCollectedPerLvl)
                {
                    EqualizeScaleImageUI(dropImage);
                    if (dropImage.transform.localScale == new Vector3(1, 1, 1))
                    {
                        dropsAreCounted = true;
                        if (dropsAreCounted == true)
                        {                           
                            //retryButton.interactable = true;
                            //homeButton.interactable = true;
                            CheckIfFinalSceneLevel();

                            //finalSceneController_Component.enabled = true;
                        }
                    }
                }
            }
            else
            {
                //allDropsCountText.enabled = false;
                pickedDropsCountText.enabled = false;
                //dropSlash.enabled = false;
                dropImage.enabled = false;
            }

        }
    }

    private void CheckIfFinalSceneLevel()
    {

        if (dropsAreCounted != true)
        {
            playButton.interactable = false;
            retryButton.interactable = false;
            homeButton.interactable = false;
        }
        else
        {
            if (SceneManager.GetActiveScene().buildIndex == finalLevelIndex)
            {
                playButton.interactable = true;
                retryButton.interactable = false;
                homeButton.interactable = false;
            }
            else
            {
                playButton.interactable = true;
                retryButton.interactable = true;
                homeButton.interactable = true;
            }
        }            
        
    }

    private void EqualizeScaleImageUI(Image objectImage)
    {
        if (objectImage.transform.localScale.y != 1.0f)
        {
            objectImage.transform.localScale += scaleChange;
            objectImage.transform.position += positionChange;

            if (objectImage.transform.localScale.y < 0.8f || objectImage.transform.localScale.y > 1.0f)
            {
                scaleChange = -scaleChange;
                positionChange = -positionChange;
            }
        }
    }

    private int CountAndScaleUI(int currentNumber, Image objectImage)
    {
        timer += Time.unscaledDeltaTime;
        if (timer > countingItemsSpeed)
        {
            currentNumber++;
            
            timer = 0f;
        }

        objectImage.transform.localScale += scaleChange;
        objectImage.transform.position += positionChange;

        // Move upwards when the coinImage hits the floor or downwards
        // when the coinImage scale extends 1.0f.
        if (objectImage.transform.localScale.y < 0.8f || objectImage.transform.localScale.y > 1.0f)
        {
            scaleChange = -scaleChange;
            positionChange = -positionChange;
        }
        isTotalScoreCalculated = true;
        return currentNumber;
    }
}
