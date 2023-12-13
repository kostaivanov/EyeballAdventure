using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobBannerFinishScene : MonoBehaviour
{
    internal BannerView bannerViewFinishScene;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
    }

    public void RequestBannerFinishScene()
    {
        string banner_Ad_ID_finish = "ca-app-pub-2055724611816187/9560685313";
        //string banner_Ad_ID_finish = "ca-app-pub-3940256099942544/6300978111";
        //Clean up banner ad before creating a new one.
        if (this.bannerViewFinishScene != null)
        {
            this.bannerViewFinishScene.Destroy();
        }
        AdSize adaptiveSize =
                AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        this.bannerViewFinishScene = new BannerView(banner_Ad_ID_finish, AdSize.SmartBanner, AdPosition.Top);
    }

    public void ShowBannerAdFinishScene()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerViewFinishScene.LoadAd(request);
    }

    public void DestroyBannerAdFinishScene()
    {
        this.bannerViewFinishScene.Destroy();
    }
}
