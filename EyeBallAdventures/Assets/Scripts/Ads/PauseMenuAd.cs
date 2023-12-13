using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuAd : MonoBehaviour
{
    [SerializeField] private GameObject adMob_Obj;
    private AdMobBannerPauseMenu adMobBannersController;

    private void OnEnable()
    {
        adMobBannersController = adMob_Obj.GetComponent<AdMobBannerPauseMenu>();
        adMobBannersController.RequestBannePauseMenu();
        adMobBannersController.ShowBannerAdPauseMenu();
    }

    private void OnDisable()
    {
        adMobBannersController.DestroyBannerAdPauseMenu();
    }
}
