using UnityEngine.Advertisements;

namespace Helpers
{
    public static class UnityAdsVideoHelper 
    {
        public static bool IsReady() => Advertisement.IsReady(placementId:"video");

        public static void Show()
        {
            Advertisement.Show(placementId:"video");
        }
        
    }
}
    
