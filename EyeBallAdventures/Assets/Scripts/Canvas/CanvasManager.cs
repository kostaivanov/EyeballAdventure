using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CanvasManager : Singleton<CanvasManager>
{
    private List<CanvasController> canvasControllerList;
    private CanvasController lastActiveCanvas;
    internal GameObject player;
    protected override void Awake()
    {
        base.Awake();
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));

    }
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 10;

        player = GameObject.FindGameObjectWithTag("Player");
        if (PermanentFunctions.instance.remainingLives >= PermanentFunctions.instance.InitialLivesCount || PermanentFunctions.instance.remainingLives < 0)
        {
            SwitchCanvas(CanvasType.IntroScene);

            StartCoroutine(LoadingIntroScene());
            //SwitchCanvas(CanvasType.MainMenu);
            Application.targetFrameRate = 10;
            
            
            player.GetComponent<PlayerMovement>().enabled = false;
        }
        else
        {
            SwitchCanvas(CanvasType.gameUI);
            Application.targetFrameRate = 60;            
        }
    }

    public void SwitchCanvas(CanvasType canvasType)
    {
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }

        CanvasController desiredCanvas = canvasControllerList.
            Find(x => x.canvastype == canvasType);

        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }

        else
        {
            Debug.LogWarning("The main menu canvas was not found!");
        }
    }

    private IEnumerator LoadingIntroScene()
    {
        
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
        SwitchCanvas(CanvasType.MainMenu);
    }
}
