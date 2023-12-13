using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratzSceneInterstitial : MonoBehaviour
{
    [SerializeField] private GameObject adMob_Obj;
    private AdMobController adMobController;

    private void OnEnable()
    {
        adMobController = adMob_Obj.GetComponent<AdMobController>();
        adMobController.RequestInterstitial();
    }
}
