// <copyright file="NativePluginHandler.cs" company="Firoozeh Technology LTD">
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


using FiroozehGameServiceAndroid.Builders;
using FiroozehGameServiceAndroid.Interfaces;
using UnityEngine;

/**
* @author Alireza Ghodrati
*/

namespace FiroozehGameServiceAndroid.Core.Native
{
    #if UNITY_ANDROID
    public static class NativePluginHandler
    {
         
        public static AndroidJavaObject GetGameServiceInstance()
        {
            var gameService = NativePluginProvider.GetGameService();
            var unityActivity = NativePluginProvider.GetUnityActivity();

            gameService.Call("SetUnityContext", unityActivity);

            return gameService;
        }        
        public static void InitGameService(
            AndroidJavaObject gameService
            ,GameServiceClientConfiguration configuration
            ,DelegateCore.OnSuccessInit onSuccess,
            DelegateCore.OnError onError)
        {

            gameService.Call("InitGameService"
                ,configuration.ClientId
                ,configuration.ClientSecret
                ,configuration.EnableLog
                ,new IGameServiceCallback(c =>
                {
                    if(c.Equals("Success"))
                        onSuccess.Invoke(gameService);
                        
                }, onError.Invoke));

        }        
    }
  #endif
}
