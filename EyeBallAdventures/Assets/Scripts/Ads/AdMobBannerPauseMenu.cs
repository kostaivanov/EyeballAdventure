using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobBannerPauseMenu : MonoBehaviour
{
    internal BannerView bannerViewPauseMenu;
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
    }
    public void RequestBannePauseMenu()
    {
        string pauseMenuBanner_Ad_ID = "ca-app-pub-2055724611816187/4828406840";
        //string pauseMenuBanner_Ad_ID = "ca-app-pub-3940256099942544/6300978111";
        // Clean up banner ad before creating a new one.
        if (this.bannerViewPauseMenu != null)
        {
            this.bannerViewPauseMenu.Destroy();
        }

        //AdSize adaptiveSize =
        //        AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
        AdSize adSize = new AdSize(320, 100);

        this.bannerViewPauseMenu = new BannerView(pauseMenuBanner_Ad_ID, adSize, AdPosition.Top);
    }

    public void ShowBannerAdPauseMenu()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerViewPauseMenu.LoadAd(request);
    }


    public void DestroyBannerAdPauseMenu()
    {
        this.bannerViewPauseMenu.Destroy();
    }
}
