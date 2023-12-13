using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobBannersController : MonoBehaviour
{
    //private string app_ID = "ca-app-pub-2055724611816187~1071730941";
    //private string banner_Ad_ID_pause = "ca-app-pub-3940256099942544/6300978111";


    //internal BannerView bannerView;
    internal BannerView bannerViewMainMenu;

    // Start is called before the first frame update

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
    }


    public void RequestBannerMainMenu()
    {
        string banner_Ad_ID_menu = "ca-app-pub-2055724611816187/1434783289";
        //string banner_Ad_ID_menu = "ca-app-pub-3940256099942544/6300978111";
        // Clean up banner ad before creating a new one.
        if (this.bannerViewMainMenu != null)
        {
            this.bannerViewMainMenu.Destroy();
        }
        //-50, 310, 
        this.bannerViewMainMenu = new BannerView(banner_Ad_ID_menu, AdSize.Banner, AdPosition.BottomLeft);
    }

    public void ShowBannerAdMainMenu()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerViewMainMenu.LoadAd(request);
    }

    public void DestroyBannerAdMainMenu()
    {
        this.bannerViewMainMenu.Destroy();
    }
}
