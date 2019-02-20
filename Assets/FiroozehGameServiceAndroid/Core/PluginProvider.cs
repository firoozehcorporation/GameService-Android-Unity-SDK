using UnityEngine;

namespace FiroozehGameServiceAndroid.Core
{
    public sealed class PluginProvider
    {

        public static AndroidJavaObject GetGameService()
        {
#if UNITY_ANDROID
            var unityInstanter = new AndroidJavaClass("ir.firoozeh.unitymodule.Handlers.UnityGameService");
            return unityInstanter.CallStatic<AndroidJavaObject>("GetInstance");
#endif
        }

        public static AndroidJavaObject GetLoginService()
        {
#if UNITY_ANDROID
            var unityInstanter = new AndroidJavaClass("ir.firoozeh.unitymodule.Handlers.UnityLogin");
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
