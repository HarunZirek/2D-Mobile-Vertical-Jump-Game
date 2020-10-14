using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adManager : MonoBehaviour, IUnityAdsListener
{
    private string playStoreID = "3835700";
    private string appStoreID = "3835701";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";
    private string reviveVideoAd = "reviveVideo";

    public bool isTargetPlayStore;
    public bool isTestAd;

    private GameObject finishLine;
    public GameObject coinAd;

   
    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();
        finishLine = GameObject.Find("finishLine");
    }

    private void InitializeAdvertisement()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreID, isTestAd);
            return;
        }
        else if (!isTargetPlayStore)
        {
            Advertisement.Initialize(appStoreID, isTestAd);
            return;
        }
    }

    public void playInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        else
        {
            Advertisement.Show(interstitialAd);
        }
    }
    public void playRewardedVideoAd()
    {
        if (!Advertisement.IsReady(rewardedVideoAd))
        {
            return;
        }
        else
        {
            Advertisement.Show(rewardedVideoAd);
        }
    }
    public void playReviveVideoAd()
    {
        if (finishLine.GetComponent<LevelComplete>().reviveCount == 1)
        {
            finishLine.GetComponent<LevelComplete>().reviveCount = 0;
            if (!Advertisement.IsReady(reviveVideoAd))
            {
                return;
            }
            else
            {
                Advertisement.Show(reviveVideoAd);
            }

        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if (placementId == reviveVideoAd)
                {
                    if (finishLine != null)
                    {
                        finishLine.GetComponent<LevelComplete>().revive();
                    }
                    return;
                }
                else if (placementId == interstitialAd)
                {
                    return;
                }
                else if (placementId == rewardedVideoAd)
                {
                    if (coinAd != null)
                    {
                        coinAd.GetComponent<coins>().AdCoin();
                    }
                    return;
                }
                break;
        }
    }
}
