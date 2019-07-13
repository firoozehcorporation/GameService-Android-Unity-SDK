using FiroozehGameServiceAndroid.Core;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Interfaces
{
    #if UNITY_ANDROID
    public class IGSNotificationListener : AndroidJavaProxy
    {
        private readonly DelegateCore.JsonData _onData;
        
        public IGSNotificationListener(DelegateCore.JsonData onData) 
            : base("ir.FiroozehCorp.GameService.UnityPackage.Native.Interfaces.NotificationListener")
        {
            _onData = onData;
        }


        void onData(string JsonData)
        {
            _onData.Invoke(JsonData);
        }
      
    }
    #endif
}