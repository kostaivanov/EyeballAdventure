using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAds : MonoBehaviour
{
    [SerializeField] private GameObject adMob_Obj;
    private AdMobBannersController adMobBannersController;
    [SerializeField] private LevelsScoreSave levelScoreSave;

    private void OnEnable()
    {
        adMobBannersController = adMob_Obj.GetComponent<AdMobBannersController>();
        //adMobBannersController.RequestBigBanner();

        adMobBannersController.RequestBannerMainMenu();
        adMobBannersController.ShowBannerAdMainMenu();
        //adMobController.RequestBigBanner();
    }

    private void OnDisable()
    {
        adMobBannersController.DestroyBannerAdMainMenu();
        levelScoreSave.levelsAndStarsActivated = false;
    }
}
