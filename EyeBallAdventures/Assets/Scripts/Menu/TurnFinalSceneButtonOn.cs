using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnFinalSceneButtonOn : MonoBehaviour
{
    private GameObject finalScene;
    private Button finalSceneHomeButton;


    public void TurnHomeButton_On()
    {
        finalScene = GameObject.FindGameObjectWithTag("FinitoScene");
        finalSceneHomeButton = finalScene.GetComponentInChildren<Button>();
        finalSceneHomeButton.interactable = true;
    }

}
