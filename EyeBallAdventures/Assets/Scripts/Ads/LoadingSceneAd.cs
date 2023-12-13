using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSceneAd : MonoBehaviour
{
    [SerializeField] private GameObject adMob_Obj;
    private AdMobBannerLoadingScene adMobLoadingSceneController;

    private void OnEnable()
    {
        adMobLoadingSceneController = adMob_Obj.GetComponent<AdMobBannerLoadingScene>();
        adMobLoadingSceneController.RequestBigBanner();
        adMobLoadingSceneController.ShowBigBannerAd();
    }

    private void OnDisable()
    {
        adMobLoadingSceneController.DestroyBigBannerAd();
    }
}
