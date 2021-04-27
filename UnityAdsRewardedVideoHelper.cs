using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Helpers
{
    public static class UnityAdsRewardedVideoHelper
    {
        public static bool IsReady() => Advertisement.IsReady(placementId:"rewardedVideo");

        public static void Show(Action<ShowResult> callback)
        {
            ShowOptions options = new ShowOptions
            {
                resultCallback = callback
            };

            Advertisement.Show(placementId:"rewardedVideo", options);

        }
    }
}