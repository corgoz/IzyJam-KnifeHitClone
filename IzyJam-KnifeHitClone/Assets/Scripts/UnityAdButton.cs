using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UnityAdButton : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private string _placementId = "rewardedVideo";

    private Button _button;

    private void Start()
    {
        Advertisement.AddListener(this);
        _button = GetComponent<Button>();

        _button.onClick.AddListener(ShowRewardedVideo);
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
        if (placementId != _placementId) return;

        if (showResult == ShowResult.Finished)
        {
            switch (placementId)
            {
                case "Coins":
                    GameManager.Singleton.GetCoin(50);
                    break;
                case "Continue":
                    GameManager.Singleton.Continue();
                    break;
            }               
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    void IUnityAdsListener.OnUnityAdsDidStart(string placementId) { }

    void IUnityAdsListener.OnUnityAdsReady(string placementId)
    {
        if (placementId == _placementId)
            _button.interactable = false;
    }
}