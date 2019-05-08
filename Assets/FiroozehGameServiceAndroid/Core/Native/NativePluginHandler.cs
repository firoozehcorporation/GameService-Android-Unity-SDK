using System;

namespace FiroozehGameServiceAndroid.Core.Native
{
    public static class NativePluginHandler
    {

        public static bool IsUserLogin()
        {
            var unityActivity = NativePluginProvider.GetUnityActivity();
            var nativeUtil = NativePluginProvider.GetNativeUtil();

            return nativeUtil.CallStatic<bool>("IsUserLogin",unityActivity);
        }

        public static void SetUserLogin(bool isLogin)
        {
            var unityActivity = NativePluginProvider.GetUnityActivity();
            var nativeUtil = NativePluginProvider.GetNativeUtil();

            nativeUtil.CallStatic("SetUserLogin",unityActivity,isLogin);
        }
    }
}
