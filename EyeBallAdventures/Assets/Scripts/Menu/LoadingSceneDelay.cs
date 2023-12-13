using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

internal class LoadingSceneDelay : MonoBehaviour
{
    [SerializeField]
    private Button retryButtonGameOver, retryButtonFinishScene;
    private CanvasManager canvasManager;
    //private bool isCoroutineExecuting = false;
    private void Start()
    {
        canvasManager = CanvasManager.GetInstance();
        retryButtonGameOver.onClick.AddListener(InvokeLoadingMenu);
        retryButtonFinishScene.onClick.AddListener(InvokeLoadingMenu);
    }

    private void InvokeLoadingMenu()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(LoadingScene(SceneManager.GetActiveScene().buildIndex));
    }

    private IEnumerator LoadingScene(int index)
    {
        canvasManager.SwitchCanvas(CanvasType.LoadingScene);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 0;

        yield return SceneManager.LoadSceneAsync(index);
        //yield return new WaitForSeconds(1f);
        Time.timeScale = 1.0f;
        canvasManager.SwitchCanvas(CanvasType.gameUI);

        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }
}
