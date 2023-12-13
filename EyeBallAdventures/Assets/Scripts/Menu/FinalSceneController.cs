using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalSceneController : MonoBehaviour
{
    private MenuButtonsController menuButtonsController;
    [SerializeField] private Button playNextLevel_FinalScene;

    private void Start()
    {
        //playNextLevel_FinalScene.interactable = false;
        menuButtonsController = GetComponent<MenuButtonsController>();
        playNextLevel_FinalScene.onClick.AddListener(menuButtonsController.LoadNextLevel);
    }


}
