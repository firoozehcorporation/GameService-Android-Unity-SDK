// <copyright file="GameServiceAppInitializer.cs" company="Firoozeh Technology LTD">
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
using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Core.App;
using FiroozehGameServiceAndroid.Enums;

/**
* @author Alireza Ghodrati
*/


namespace FiroozehGameServiceAndroid.Builders.App
{
    #if UNITY_ANDROID
    internal static class GameServiceAppInitializer
    {
        internal static void Init(
            GameServiceClientConfiguration configuration
            ,Action<GameService> onSuccess
            ,Action<string> onError)
        {

                FiroozehGameServiceAppLoginCheck.CheckUserLoginStatus(
                    configuration.CheckAppStatus
                    , configuration.CheckOptionalUpdate
                    ,configuration.EnableLog
                    , isLogin =>
                    {
                        if (isLogin)
                        {
                            AppPluginHandler.InitGameService(
                                configuration.ClientId,configuration.ClientSecret,configuration.EnableLog,
                                s => { onSuccess.Invoke(new GameService(s,GameServiceType.App, configuration.HaveNotification)); }
                                ,onError.Invoke);
                        }      
                        else
                            FiroozehGameServiceAppLoginCheck.ShowLoginUI(
                                configuration.CheckAppStatus
                                , configuration.CheckOptionalUpdate
                                ,configuration.EnableLog
                                , r =>
                                {
                                    if (r)
                                    {
                                        AppPluginHandler.InitGameService(
                                            configuration.ClientId, configuration.ClientSecret,configuration.EnableLog,
                                            s =>
                                            {
                                                onSuccess.Invoke(new GameService(s,GameServiceType.App, configuration.HaveNotification));
                                            }
                                            , onError.Invoke);
                                    }
                                }, onError.Invoke);
                    }, onError.Invoke);
            
        }
    }
#endif

}