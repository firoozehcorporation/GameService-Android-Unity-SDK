using FiroozehGameServiceAndroid.Core;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Utils
{
    public static class DeviceInformationUtil
    {
        public static bool IsGameServiceAppInstalled()
        {
            var unityActivity = PluginProvider.GetUnityActivity();
            var deviceInformationUtil = PluginProvider.GetDeviceInformationUtilClass();
            
            return deviceInformationUtil.CallStatic<bool>("isGameServiceInstalled",unityActivity);
            
        }
    }
}