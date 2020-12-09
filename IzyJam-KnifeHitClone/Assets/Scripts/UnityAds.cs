using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class UnityAds : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private string _appId;
    [SerializeField] private bool _isTestMode;
    [SerializeField] private string _placementId = "rewardedVideo";

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_appId, _isTestMode);
    }

    private void OnDestroy() => Advertisement.RemoveListener(this);
    public void ShowRewardedVideo()
    {
        if (Advertisement.IsReady(_placementId))
            Advertisement.Show(_placementId);
        else
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
    }

    void IUnityAdsListener.OnUnityAdsDidError(string message) { }

    void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    void IUnityAdsListener.OnUnityAdsDidStart(string placementId) { }

    void IUnityAdsListener.OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == _placementId)
        {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }


}
