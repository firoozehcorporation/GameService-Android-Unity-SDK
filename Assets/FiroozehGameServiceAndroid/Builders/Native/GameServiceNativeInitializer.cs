// <copyright file="GameServiceNativeInitializer.cs" company="Firoozeh Technology LTD">
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
using FiroozehGameServiceAndroid.Enums;

/**
* @author Alireza Ghodrati
*/

namespace FiroozehGameServiceAndroid.Builders.Native
{
#if UNITY_ANDROID
    /// <summary>
    /// Represents Initialize GameService In Native Mode.
    /// </summary>
    internal static class GameServiceNativeInitializer
    {
        internal static void Init(GameServiceClientConfiguration configuration
            ,Action<GameService> onSuccess
            ,Action<string> onError)
        {
            var nativeService = NativePluginHandler.GetGameServiceInstance();
            NativePluginHandler.InitGameService(
                nativeService
                ,configuration
                ,gameService=>{ onSuccess.Invoke(new GameService(gameService,GameServiceType.Native,configuration.HaveNotification));}
                ,onError.Invoke,configuration.NotificationListener);
        }
    }
#endif
}
