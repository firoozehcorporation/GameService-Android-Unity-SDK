using UnityEngine;

namespace FiroozehGameServiceAndroid.Core.App
{
    public static class AppPluginProvider
    {

        public static AndroidJavaObject GetGameService()
        {
#if UNITY_ANDROID
            var unityInstanter = new AndroidJavaClass("ir.FiroozehCorp.UnityPlugin.App.Handlers.UnityGameService");
            return unityInstanter.CallStatic<AndroidJavaObject>("GetInstance");
#endif
        }

        public static AndroidJavaObject GetLoginService()
        {
#if UNITY_ANDROID
            var unityInstanter = new AndroidJavaClass("ir.FiroozehCorp.UnityPlugin.App.Handlers.UnityLoginService");
            return unityInstanter.CallStatic<AndroidJavaObject>("GetInstance");
#endif
        }

        public static AndroidJavaObject GetUnityActivity()
        {
            var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }

      

    }
}
