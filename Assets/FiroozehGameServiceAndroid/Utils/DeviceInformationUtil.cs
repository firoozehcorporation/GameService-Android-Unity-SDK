using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Core.App;
using FiroozehGameServiceAndroid.Core.Native;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Utils
{
    public static class DeviceInformationUtil
    {
        public static bool IsGameServiceAppInstalled()
        {
            var unityActivity = NativePluginProvider.GetUnityActivity();
            var deviceInformationUtil = NativePluginProvider.GetDeviceInformationUtilClass();
            
            return deviceInformationUtil.CallStatic<bool>("isGameServiceInstalled",unityActivity);
            
        }
    }
}