using UnityEngine;

namespace FiroozehGameServiceAndroid.Core
{
    public static class PluginProvider
    {

        public static AndroidJavaObject GetGameService()
        {
#if UNITY_ANDROID
            var unityInstanter = new AndroidJavaClass("ir.FiroozehCorp.UnityPlugin.Handlers.UnityGameService");
            return unityInstanter.CallStatic<AndroidJavaObject>("GetInstance");
#endif
        }

        public static AndroidJavaObject GetLoginService()
        {
#if UNITY_ANDROID
            var unityInstanter = new AndroidJavaClass("ir.FiroozehCorp.UnityPlugin.Handlers.UnityLoginService");
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
