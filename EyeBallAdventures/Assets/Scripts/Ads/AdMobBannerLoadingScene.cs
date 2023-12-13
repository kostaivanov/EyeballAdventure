using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobBannerLoadingScene : MonoBehaviour
{
    internal BannerView bigBannerView;

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
    }

    //Start is called before the first frame update
    public void RequestBigBanner()
    {
        string bigBanner_Ad_ID = "ca-app-pub-2055724611816187/3869374933";
        //string bigBanner_Ad_ID = "ca-app-pub-3940256099942544/6300978111";
        //Clean up banner ad before creating a new one.
        //if (this.bigBannerView != null)
        //{
        //    this.bigBannerView.Destroy();
        //}

        AdSize adSize = new AdSize(300, 250);
        // Create a 320x50 banner at the top of the screen.
        this.bigBannerView = new BannerView(bigBanner_Ad_ID, adSize, AdPosition.Top);

        //// Called when an ad request has successfully loaded.
        //this.bigBannerView.OnAdLoaded += this.HandleOnAdLoaded;
        //// Called when an ad request failed to load.
        //this.bigBannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        //// Called when an ad is clicked.
        //this.bigBannerView.OnAdOpening += this.HandleOnAdOpened;
        //// Called when the user returned from the app after an ad click.
        //this.bigBannerView.OnAdClosed += this.HandleOnAdClosed;
        //// Called when the ad click caused the user to leave the application.
        //this.bigBannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
    }

    public void ShowBigBannerAd()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bigBannerView.LoadAd(request);
    }

    public void DestroyBigBannerAd()
    {
        this.bigBannerView.Destroy();
    }
}
