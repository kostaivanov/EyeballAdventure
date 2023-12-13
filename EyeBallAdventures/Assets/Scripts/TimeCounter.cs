using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

internal class TimeCounter : MonoBehaviour
{
    //private static TimeCounter instance;
    [SerializeField] internal TextMeshProUGUI timer;
    private GameObject player;
    [SerializeField] internal GameObject gameUIScene;
    internal float seconds, minutes;
    internal float time;
    internal float savedTime = 0;
    private bool isAlive;
    private bool isCoroutineExecuting = false;

    private void Start()
    {
        //time = savedTime;
        isAlive = false;
    }


    private void Update()
    {
        if (gameUIScene.activeSelf == true)
        {
            if (player == null)
            {
                if (isAlive == false)
                {
                    player = GameObject.FindGameObjectWithTag("Player");

                    isAlive = true;
                }

                if (isAlive == true)
                {
                    StartCoroutine(WaitForPlayerToRevive());
                }
  
            }
            
            if (player != null)
            {
                CountTime();
                
                //timer.text = savedMinutes.ToString("00") + ":" + savedSeconds.ToString("00");
            }
        }
        
    }

    private IEnumerator WaitForPlayerToRevive()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;
        

        yield return new WaitForSeconds(0.5f);

        player = GameObject.FindGameObjectWithTag("Player");
        isCoroutineExecuting = false;
    }


    private void CountTime()
    {
        time += Time.deltaTime;
        seconds = Mathf.Floor(time % 60);
        minutes = Mathf.Floor(time / 60);
        
        timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
