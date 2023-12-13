using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsScoreSave : MonoBehaviour
{
    [SerializeField] private GameObject starsObject;
    [SerializeField] private GameObject levelsObject;
    private List<GameObject> stars;
    private List<GameObject> levels;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject inGameSceneUI;
    //private FinishedLevelStarsController finishedLevelStarsController;

    private FinishSceneController finishSceneController;

    internal GameObject player;
    //private int starIndex;
    private int levelStarValue = 0;
    internal bool levelsAndStarsActivated;
    //private Dictionary<int, int> allLevelsTotalScore;

    private int levelUnlocked;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        levelsAndStarsActivated = false;
        //finishedLevelStarsController = GetComponent<FinishedLevelStarsController>();

        finishSceneController = GetComponent<FinishSceneController>();

        //player = GameObject.FindGameObjectWithTag("Player");
        //PermanentFunctions.instance.levelCompletedStars = 0;
        stars = new List<GameObject>();
        levels = new List<GameObject>();
        AddChildrenToList(levelsObject.transform, starsObject.transform, "LevelNumber");

        for (int i = 0, j = 1; i < stars.Count && j < levels.Count; i++, j++)
        {
            stars[i].transform.GetChild(0).gameObject.SetActive(false);
            stars[i].transform.GetChild(1).gameObject.SetActive(false);
            stars[i].transform.GetChild(2).gameObject.SetActive(false);
            levels[j].gameObject.SetActive(false);
        }

        //for (int j = 1; j < levels.Count; j++)
        //{
        //    levels[j].gameObject.SetActive(false);
        //}
        //int index = 1;
        //foreach (var star in stars)
        //{
        //    //star.transform.GetChild(0).gameObject.SetActive(false);
        //    //star.transform.GetChild(1).gameObject.SetActive(false);
        //    //star.transform.GetChild(2).gameObject.SetActive(false);
        //    //levels[index].SetActive(false);
        //    //index++;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (this.mainMenu.activeSelf == true && levelsAndStarsActivated == false)
        {
            foreach (Levels level in Enum.GetValues(typeof(Levels)))
            {
                if (PlayerPrefs.GetInt("Button" + level.ToString()) != 0 && (int)level < 11)
                {                    
                    levels[(int)level + 1].gameObject.SetActive(true);
                }

                if (PlayerPrefs.GetInt(level.ToString()) == 0)
                {
                    stars[(int)level].transform.GetChild(0).gameObject.SetActive(false);
                    stars[(int)level].transform.GetChild(1).gameObject.SetActive(false);
                    stars[(int)level].transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    SetStarScore(level);
                }
            }
            levelsAndStarsActivated = true;
        }

        if (this.inGameSceneUI.activeSelf == true)
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
        }
    }

    private void SetStarScore(Levels level)
    {
        switch (level)
        {
            case Levels.Level_1:
                levelStarValue = PlayerPrefs.GetInt(Levels.Level_1.ToString());
                if (levelStarValue > 0)
                {
                    stars[(int)Levels.Level_1].transform.GetChild(levelStarValue - 1).gameObject.SetActive(true);
                }

                break;
            case Levels.Level_2:
                levelStarValue = PlayerPrefs.GetInt(Levels.Level_2.ToString());
                levelUnlocked = PlayerPrefs.GetInt("Button" + Levels.Level_1.ToString());
                if (levelStarValue > 0 && levelUnlocked > 0)
                {
                    stars[(int)Levels.Level_2].transform.GetChild(levelStarValue - 1).gameObject.SetActive(true);
                }
                break;
            case Levels.Level_3:
                levelStarValue = PlayerPrefs.GetInt(Levels.Level_3.ToString());
                //levelUnlocked = PlayerPrefs.GetInt("Button" + Levels.Level_3.ToString());
                if (levelStarValue > 0 && levelUnlocked > 0)
                {
                    stars[(int)Levels.Level_3].transform.GetChild(levelStarValue - 1).gameObject.SetActive(true);
                }
                break;
            case Levels.Level_4:
                levelStarValue = PlayerPrefs.GetInt(Levels.Level_4.ToString());
                //levelUnlocked = PlayerPrefs.GetInt("Button" + Levels.Level_4.ToString());
                if (levelStarValue > 0 && levelUnlocked > 0)
                {
                    stars[(int)Levels.Level_4].transform.GetChild(levelStarValue - 1).gameObject.SetActive(true);
                }
                break;
            case Levels.Level_5:
                levelStarValue = PlayerPrefs.GetInt(Levels.Level_4.ToString());
                //levelUnlocked = PlayerPrefs.GetInt("Button" + Levels.Level_5.ToString());
                if (levelStarValue > 0 && levelUnlocked > 0)
                {
                    stars[(int)Levels.Level_5].transform.GetChild(levelStarValue - 1).gameObject.SetActive(true);
                }
                break;
            case Levels.Level_6:
                levelStarValue = PlayerPrefs.GetInt(Levels.Level_6.ToString());
                //levelUnlocked = PlayerPrefs.GetInt("Button" + Levels.Level_6.ToString());
                if (levelStarValue > 0 && levelUnlocked > 0)
                {
                    stars[(int)Levels.Level_6].transform.GetChild(levelStarValue - 1).gameObject.SetActive(true);
                }
                break;
            case Levels.Level_7:
                levelStarValue = PlayerPrefs.GetInt(Levels.Level_7.ToString());
                //levelUnlocked = PlayerPrefs.GetInt("Button" + Levels.Level_7.ToString());
                if (levelStarValue > 0 && levelUnlocked > 0)
                {
                    stars[(int)Levels.Level_7].transform.GetChild(levelStarValue - 1).gameObject.SetActive(true);
                }
                break;
            case Levels.Level_8:
                levelStarValue = PlayerPrefs.GetInt(Levels.Level_8.ToString());
                //levelUnlocked = PlayerPrefs.GetInt("Button" + Levels.Level_8.ToString());
                if (levelStarValue > 0 && levelUnlocked > 0)
                {
                    stars[(int)Levels.Level_8].transform.GetChild(levelStarValue - 1).gameObject.SetActive(true);
                }
                break;
            case Levels.Level_9:
                levelStarValue = PlayerPrefs.GetInt(Levels.Level_9.ToString());
                //levelUnlocked = PlayerPrefs.GetInt("Button" + Levels.Level_9.ToString());
                if (levelStarValue > 0 && levelUnlocked > 0)
                {
                    stars[(int)Levels.Level_9].transform.GetChild(levelStarValue - 1).gameObject.SetActive(true);
                }
                break;
            case Levels.Level_10:
                levelStarValue = PlayerPrefs.GetInt(Levels.Level_10.ToString());
                //levelUnlocked = PlayerPrefs.GetInt("Button" + Levels.Level_10.ToString());
                if (levelStarValue > 0 && levelUnlocked > 0)
                {
                    stars[(int)Levels.Level_10].transform.GetChild(levelStarValue - 1).gameObject.SetActive(true);
                }
                break;
            case Levels.Level_11:
                levelStarValue = PlayerPrefs.GetInt(Levels.Level_11.ToString());
                //levelUnlocked = PlayerPrefs.GetInt("Button" + Levels.Level_11.ToString());
                if (levelStarValue > 0 && levelUnlocked > 0)
                {
                    stars[(int)Levels.Level_11].transform.GetChild(levelStarValue - 1).gameObject.SetActive(true);
                }
                break;
            case Levels.Level_12:
                levelStarValue = PlayerPrefs.GetInt(Levels.Level_12.ToString());
                //levelUnlocked = PlayerPrefs.GetInt("Button" + Levels.Level_12.ToString());
                if (levelStarValue > 0 && levelUnlocked > 0)
                {
                    stars[(int)Levels.Level_12].transform.GetChild(levelStarValue - 1).gameObject.SetActive(true);
                }
                break;
            default:
                break;
        }
    }

    private void AddChildrenToList(Transform parentLevels, Transform parentStars, string childTag)
    {
        //foreach (Transform child in parent)
        //{

        //    if (child.CompareTag(childTag))
        //    {
        //        stars.Add(child.gameObject);
        //        //levels.Add(levelsObject.transform.GetChild(index).gameObject);

        //    }
        //    //AddChildrenToList(child, childTag);
        //}

        for (int i = 0; i < parentStars.childCount; i++)
        {
            stars.Add(parentStars.transform.GetChild(i).gameObject);
            levels.Add(parentLevels.transform.GetChild(i).gameObject);
        }
    }
}
