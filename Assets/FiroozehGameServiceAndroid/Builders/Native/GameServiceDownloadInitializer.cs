using System;
using FiroozehGameServiceAndroid.Core.Native;
using FiroozehGameServiceAndroid.Interfaces;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Builders.Native
{
    public static class GameServiceDownloadInitializer
    {
        private static AndroidJavaObject _objDownload;


        public static void DownloadData(string obbDataTag , Action<string> callback)
        {
            _objDownload = NativePluginProvider.GetDownloadHandler();
            _objDownload.Call(obbDataTag,new IGameServiceCallback(callback.Invoke,callback.Invoke));
        }

        public static bool CancelDownload()
        {
            return _objDownload != null  && _objDownload.Call<bool>("CancelDownload");
        }
        
    }
}