using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class RestartGame : MonoBehaviour
{
    [SerializeField] internal float restartTime;
    private float resetTime;
    private bool restartNow = false;

    private void Start()
    {
        //canvasManager = CanvasManager.GetInstance();
       
    }
    // Update is called once per frame
    internal void Update()
    {
        if (restartNow && resetTime <= Time.time)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
        }
    }

    internal void RestartTheGame()
    {
        Application.targetFrameRate = 30;
        
        resetTime = Time.time + restartTime;
        restartNow = true;
    }
}
