using UnityEngine;

namespace FiroozehGameServiceAndroid.Core.Native
{
    public static class NativePluginProvider
    {
        public static AndroidJavaObject GetUnityActivity()
        {
            var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }
        
        public static AndroidJavaClass GetDeviceInformationUtilClass()
        {
            return new AndroidJavaClass("ir.FiroozehCorp.UnityPlugin.Utils.DeviceInformationUtil");
        }

        public static AndroidJavaClass GetNativeUtil()
        {
           return new AndroidJavaClass("ir.FiroozehCorp.UnityPlugin.Utils.NativeUtil");
        }
    }
}