using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using Helpers;

public class UnityAdsHelper : MonoBehaviour
{
    private string GameId;

    [Header("Game IDs")]
    [SerializeField] private string GooglePlayAppId;
    [SerializeField] private string AppStoreAppId;

    [Header("BannerPosition")]
    [SerializeField] private BannerPosition BannerPos;
    
    private void Awake()
    {
#if UNITY_ANDROID
        GameId = this.GooglePlayAppId;
#elif UNITY_IOS 
        GameId = this.AppStoreAppId;
#endif
        Advertisement.Initialize(GameId);
    }
    
    public void ShowVideoAd()
    {
        if (UnityAdsVideoHelper.IsReady())
        {
            UnityAdsVideoHelper.Show();
        }
    }

    public void ShowRewardedVideoAd(Action<ShowResult> callback)
    {
        if (UnityAdsRewardedVideoHelper.IsReady())
        {
            UnityAdsRewardedVideoHelper.Show(callback);
        }
    }

    public void ShowBannerAd()
    {
        StartCoroutine(routine:ShowBannerWhenReady());
    }

    public bool VideoAdIsReady() => UnityAdsVideoHelper.IsReady();

    public bool RewardedVideoIsReady() => UnityAdsRewardedVideoHelper.IsReady();

    public bool BannerIsReady() => UnityAdsBannerHelper.IsReady();

    private IEnumerator ShowBannerWhenReady()
    {
        while (!UnityAdsBannerHelper.IsReady())
        {
            yield return new WaitForSeconds(0.25f);
        }
        UnityAdsBannerHelper.Show(this.BannerPos);
    }

    public void DemoRewardedVideoAd()
    {
        ShowRewardedVideoAd(result =>
        {
            switch (result)
            {
                case ShowResult.Failed:
                    Debug.Log(message:"Show Result => Failed");
                    break;
                
                case ShowResult.Finished:
                    Debug.Log(message:"Show Result => Finished");
                    break;
                
                case ShowResult.Skiped:
                    Debug.Log(message:"Show Result => Skiped");
                    break;
            }

        });
    }

}
