// <copyright file="AppPluginHandler.cs" company="Firoozeh Technology LTD">
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

using FiroozehGameServiceAndroid.Enums;
using FiroozehGameServiceAndroid.Interfaces;
using FiroozehGameServiceAndroid.Interfaces.App;
using UnityEngine;

/**
* @author Alireza Ghodrati
*/

namespace FiroozehGameServiceAndroid.Core.App
{
    #if UNITY_ANDROID
    /// <summary>
    /// Represents Game Service Plugin Handler In App Mode
    /// </summary>
    public static class AppPluginHandler {

        private static AndroidJavaObject GetGameServiceInstance()
        {
            var gameService = AppPluginProvider.GetGameService();
            var unityActivity = AppPluginProvider.GetUnityActivity();

            gameService.Call("SetUnityContext", unityActivity);

            return gameService;
        }

        private static AndroidJavaObject GetGameLoginServiceInstance()
        {
            var loginService = AppPluginProvider.GetLoginService();
            var unityActivity = AppPluginProvider.GetUnityActivity();

            loginService.Call("SetUnityContext", unityActivity);

            return loginService;
        }

        public static void InitGameService(
             string clientId
            ,string clientSecret
            ,bool logEnable
            ,bool isGuest
            ,DelegateCore.OnSuccessInit onSuccess
            ,DelegateCore.OnError onError
            ,DelegateCore.NotificationListener notificationListener
            )
        {
   
            var gameService = GetGameServiceInstance();

            gameService.Call("InitGameService",
                clientId,
                clientSecret,
                logEnable,
                isGuest,
                new IGameServiceCallback(callBack => {
                        if(callBack.Equals("Success"))
                            onSuccess.Invoke(gameService);
                    },
                    onError.Invoke)
                ,new IGSNotificationListener(l =>
                {
                    if(notificationListener != null)
                        notificationListener.Invoke(l);
                }));
        }

        public static void InitGameLoginService(
             bool checkAppStatus
            ,bool checkOptionalUpdate
             ,bool logEnable
            ,DelegateCore.OnSuccessInit onSuccess,
            DelegateCore.OnError onError)
        {

            var loginService = GetGameLoginServiceInstance();

            loginService.Call("InitLoginService",
                checkAppStatus,
                checkOptionalUpdate
                ,logEnable,
                new IGameServiceCallback(callBack => {
                        if (callBack.Equals("Success"))
                            onSuccess.Invoke(loginService);
                    },
                    onError.Invoke));
        }
    }
    #endif
}
