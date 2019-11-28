// <copyright file="GameServiceDownloadInitializer.cs" company="Firoozeh Technology LTD">
// Copyright (C) 2019 Firoozeh Technology LTD. All Rights Reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>




using System;
using FiroozehGameServiceAndroid.Core.Native;
using FiroozehGameServiceAndroid.Interfaces;
using FiroozehGameServiceAndroid.Utils;
using UnityEngine;

/**
* @author Alireza Ghodrati
*/

namespace FiroozehGameServiceAndroid.Builders.Native
{
    /// <summary>
    /// Represents Game Data Download System
    /// </summary>
   
    internal static class GameServiceDownloadInitializer
    {
        private const string Tag = "GameServiceDownloadInitializer";
        private static AndroidJavaObject _objDownload;

        internal static void DownloadData(GameServiceClientConfiguration configuration , Action<string> callback,Action<string> error)
        {
            LogUtil.LogDebug(Tag,"DataDownloadStarted");
            _objDownload = NativePluginHandler.GetDownloadInstance();
            _objDownload.Call("DownloadObbDataFile",
                configuration.ClientId
                ,configuration.DownloadTag
                ,new IGameServiceCallback(callback.Invoke,error.Invoke));
        }
        
        internal static void DownloadAsset(string tag,GameServiceClientConfiguration configuration , Action<string> callback,Action<string> error)
        {
            LogUtil.LogDebug(Tag,"DownloadAssetStarted");
            _objDownload = NativePluginHandler.GetDownloadInstance();
            _objDownload.Call("DownloadAssetFile",
                configuration.ClientId
                ,tag
                ,new IGameServiceCallback(callback.Invoke,error.Invoke));
        }

        internal static bool CancelDownloadData()
        {
            return _objDownload != null  && _objDownload.Call<bool>("CancelDownload");
        }
        
    }
}