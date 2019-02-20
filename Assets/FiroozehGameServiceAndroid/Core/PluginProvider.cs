using UnityEngine;

namespace FiroozehGameServiceAndroid.Core
{
    public sealed class PluginProvider
    {

        public static AndroidJavaObject GetGameService()
        {
#if UNITY_ANDROID
            var UnityInstanter = new AndroidJavaClass("ir.firoozeh.unitymodule.Handlers.UnityGameService");
            return UnityInstanter.CallStatic<AndroidJavaObject>("GetInstance");
#endif
        }

        public static AndroidJavaObject GetLoginService()
        {
#if UNITY_ANDROID
            var UnityInstanter = new AndroidJavaClass("ir.firoozeh.unitymodule.Handlers.UnityLogin");
            return UnityInstanter.CallStatic<AndroidJavaObject>("GetInstance");
#endif
        }

        public static AndroidJavaObject GetUnityActivity()
        {
            var UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            return UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }

    }
}
