using System;
using FiroozehGameServiceAndroid.Core.Native;
using FiroozehGameServiceAndroid.Interfaces;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Builders.Native
{
    public static class GameServiceDownloadInitializer
    {
        private static AndroidJavaObject _objDownload;


        public static void DownloadData(GameServiceClientConfiguration configuration , Action<string> callback)
        {
            _objDownload = NativePluginProvider.GetDownloadHandler();
            _objDownload.Call("DownloadObbDataFile",
                configuration.ClientId
                ,configuration.DownloadTag
                ,new IGameServiceCallback(callback.Invoke,callback.Invoke));
        }

        public static bool CancelDownload()
        {
            return _objDownload != null  && _objDownload.Call<bool>("CancelDownload");
        }
        
    }
}