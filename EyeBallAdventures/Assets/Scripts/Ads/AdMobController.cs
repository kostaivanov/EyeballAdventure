using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobController : MonoBehaviour
{
    private string app_ID = "ca-app-pub-2055724611816187~1071730941";
    //private string banner_Ad_ID = "ca-app-pub-3940256099942544/6300978111";
    
    private string interstitial_Ad_ID = "ca-app-pub-2055724611816187/5645743654";
    private string rewardedVideo_Ad_ID = "ca-app-pub-2055724611816187/6767253633";

    //internal BannerView bannerView;
    //internal BannerView bigBannerView;
    //internal BannerView bannerViewMainMenu;
    //internal BannerView bannerViewFinishScene;
    //internal BannerView bannerViewPauseMenu;

    internal InterstitialAd interstitial;
    private RewardedAd rewardedAd;

    // Start is called before the first frame update
    [Obsolete]
    void Start()
    {
        MobileAds.Initialize(app_ID);
    }


    public void RequestInterstitial()
    {

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(interstitial_Ad_ID);

        //// Called when an ad request has successfully loaded.
        //this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        //// Called when an ad request failed to load.
        //this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        //// Called when an ad is shown.
        //this.interstitial.OnAdOpening += HandleOnAdOpened;
        //// Called when the ad is closed.
        //this.interstitial.OnAdClosed += HandleOnAdClosed;
        //// Called when the ad click caused the user to leave the application.
        //this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;


        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    public void ShowInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    public void RequestRewardBasedVideo()
    {
        this.rewardedAd = new RewardedAd(rewardedVideo_Ad_ID);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void ShowVideoRewardAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    //Fore events and delagates for ads
    //public void HandleOnAdLoaded(object sender, EventArgs args)
    //{
    //    //if (this.interstitial.IsLoaded())
    //    //{
    //    //    this.interstitial.Show();
    //    //}
    //}

    //public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    //{

    //}

    //public void HandleOnAdOpened(object sender, EventArgs args)
    //{
    //    MonoBehaviour.print("HandleAdOpened event received");
    //}

    //public void HandleOnAdClosed(object sender, EventArgs args)
    //{
    //    MonoBehaviour.print("HandleAdClosed event received");
    //}

    //public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    //{
    //    MonoBehaviour.print("HandleAdLeavingApplication event received");
    //}
}
