using UnityEngine;
using UnityEngine.Advertisements;

namespace Helpers
{
    public static class UnityAdsBunnerHelper
    {
        public static bool IsReady() => Advertisement.IsReady(placementId:"banner");

        public static void show(BannerPosition pos)
        {
            Advertisement.Banner.SetPosition(pos);
            Advertisement.Banner.Show(placementId:"banner");
        }   
    }
}
