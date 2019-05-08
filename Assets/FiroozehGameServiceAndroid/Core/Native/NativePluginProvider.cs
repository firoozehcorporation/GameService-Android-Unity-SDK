using UnityEngine;

namespace FiroozehGameServiceAndroid.Core.Native
{
    public static class NativePluginProvider
    {
       #if UNITY_ANDROID
        public static AndroidJavaObject GetGameService()
        {
            var unityInstanter = new AndroidJavaClass("ir.FiroozehCorp.UnityPlugin.Native.Handlers.UnityGameServiceNative");
            return unityInstanter.CallStatic<AndroidJavaObject>("GetInstance");
        }
       #endif
       #if UNITY_ANDROID
        public static AndroidJavaObject GetUnityActivity()
        {
            var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }
        #endif
        #if UNITY_ANDROID
        public static AndroidJavaClass GetDeviceInformationUtilClass()
        {
            return new AndroidJavaClass("ir.FiroozehCorp.UnityPlugin.Utils.DeviceInformationUtil");
        }
        #endif
        #if UNITY_ANDROID
        public static AndroidJavaClass GetNativeHandlerClass()
        {
            return new AndroidJavaClass("ir.FiroozehCorp.UnityPlugin.Native.Handlers.UnityGameServiceNative");
        }
         #endif
    }
}