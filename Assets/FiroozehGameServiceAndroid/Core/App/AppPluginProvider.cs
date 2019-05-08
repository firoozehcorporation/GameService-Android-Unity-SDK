// <copyright file="AppPluginProvider.cs" company="Firoozeh Technology LTD">
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

using UnityEngine;

/**
* @author Alireza Ghodrati
*/

namespace FiroozehGameServiceAndroid.Core.App
{
    #if UNITY_ANDROID
    public static class AppPluginProvider
    {

        public static AndroidJavaObject GetGameService()
        {
            var unityInstanter = new AndroidJavaClass("ir.FiroozehCorp.UnityPlugin.App.Handlers.UnityGameService");
            return unityInstanter.CallStatic<AndroidJavaObject>("GetInstance");
        }

        public static AndroidJavaObject GetLoginService()
        {
            var unityInstanter = new AndroidJavaClass("ir.FiroozehCorp.UnityPlugin.App.Handlers.UnityLoginService");
            return unityInstanter.CallStatic<AndroidJavaObject>("GetInstance");
        }

        public static AndroidJavaObject GetUnityActivity()
        {
            var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }
    #endif
}
