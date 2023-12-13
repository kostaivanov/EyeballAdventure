using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSceneBannerShow : MonoBehaviour
{
    [SerializeField] private GameObject adMobFinishBanner_Obj;
    [SerializeField] private GameObject adMob_Obj;
    private AdMobBannerFinishScene adMobBannerFinishSceneController;
    private AdMobController adMobController;
    private void OnEnable()
    {
        adMobBannerFinishSceneController = adMobFinishBanner_Obj.GetComponent<AdMobBannerFinishScene>();
        adMobController = adMob_Obj.GetComponent<AdMobController>();

        adMobBannerFinishSceneController.RequestBannerFinishScene();
        adMobBannerFinishSceneController.ShowBannerAdFinishScene();

        adMobController.RequestRewardBasedVideo();
    }

    private void OnDisable()
    {
        adMobBannerFinishSceneController.DestroyBannerAdFinishScene();
    }
}
