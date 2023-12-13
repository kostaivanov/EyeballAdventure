using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedLevelStarsController : MonoBehaviour
{
    private FinishSceneController finishSceneController;
    private int totalScore;
    [SerializeField] private GameObject levelCompletedStars_1;
    [SerializeField] private GameObject levelCompletedStars_2;
    [SerializeField] private GameObject levelCompletedStars_3;
    [SerializeField] private GameObject finishScene;
    
    internal int starsTemporaryValue;
    private int currentSceneIndex;
    // Start is called before the first frame update


    private void Awake()
    {

        if (!PlayerPrefs.HasKey("Score_" + Levels.Level_1.ToString()))
        {
            PlayerPrefs.SetString("Score_" + Levels.Level_1.ToString(), "700_400_5");
            PlayerPrefs.SetString("Score_" + Levels.Level_2.ToString(), "1250_700_5");
            PlayerPrefs.SetString("Score_" + Levels.Level_3.ToString(), "1700_1000_5");
            PlayerPrefs.SetString("Score_" + Levels.Level_4.ToString(), "1700_1100_4");
            PlayerPrefs.SetString("Score_" + Levels.Level_5.ToString(), "2500_1500_5");
            PlayerPrefs.SetString("Score_" + Levels.Level_6.ToString(), "2750_1750_5");
            PlayerPrefs.SetString("Score_" + Levels.Level_7.ToString(), "2000_1200_5");
            PlayerPrefs.SetString("Score_" + Levels.Level_8.ToString(), "2950_1950_5");
            PlayerPrefs.SetString("Score_" + Levels.Level_9.ToString(), "2800_1800_5");
            PlayerPrefs.SetString("Score_" + Levels.Level_10.ToString(), "2700_1700_6");
            PlayerPrefs.SetString("Score_" + Levels.Level_11.ToString(), "2700_1700_6");
            PlayerPrefs.SetString("Score_" + Levels.Level_12.ToString(), "2800_1800_7");
        }

    }

    private void Start()
    {
        levelCompletedStars_1.SetActive(false);
        levelCompletedStars_2.SetActive(false);
        levelCompletedStars_3.SetActive(false);

        finishSceneController = GetComponent<FinishSceneController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (finishScene.activeSelf == true)
        {
            if (finishSceneController.dropsAreCounted == true)
            {
                currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                totalScore = finishSceneController.TotalScore;

                Levels currentLevel = (Levels)currentSceneIndex;
                //SetScoreEachLevel(currentLevel);
                string stringLevelValue = ((Levels)currentSceneIndex).ToString();

                for (int i = 0; i < 12; i++)
                {
                    if (currentSceneIndex == i)
                    {
                        string currentLevelString = PlayerPrefs.GetString("Score_" + stringLevelValue);
                        string[] input = currentLevelString.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

                        if (totalScore >= int.Parse(input[0]) && finishSceneController.timeCounter.time < float.Parse(input[2]) * 60)
                        {
                            levelCompletedStars_3.SetActive(true);
                            starsTemporaryValue = 3;
                            SetLevelHighestScore(starsTemporaryValue, totalScore);
                            
                        }
                        else if (totalScore >= int.Parse(input[1]) && totalScore < int.Parse(input[0]))
                        {
                            levelCompletedStars_2.SetActive(true);
                            starsTemporaryValue = 2;
                            SetLevelHighestScore(starsTemporaryValue, totalScore);
                        }
                        else if (totalScore < int.Parse(input[1]))
                        {
                            levelCompletedStars_1.SetActive(true);
                            starsTemporaryValue = 1;
                            SetLevelHighestScore(starsTemporaryValue, totalScore);
                        }
                    }
                }
            }
            else
            {
                levelCompletedStars_1.SetActive(false);
                levelCompletedStars_2.SetActive(false);
                levelCompletedStars_3.SetActive(false);
            }
        }      
    }

    private void SetLevelHighestScore(int starValue, int totalScore)
    {
        if (starValue > 0)
        {           
            foreach (Levels level in Enum.GetValues(typeof(Levels)))
            {
                if ((int)level == currentSceneIndex)
                {
                    if (PlayerPrefs.GetInt(level.ToString()) < starValue)
                    {
                        PlayerPrefs.SetInt(level.ToString(), starValue);
                        PlayerPrefs.SetInt("Button" + level.ToString(), 1);
                        //PlayerPrefs.SetInt(currentSceneIndex + "LevelScore", totalScore);
                    }
                }
            }
        }
        
    }
}
