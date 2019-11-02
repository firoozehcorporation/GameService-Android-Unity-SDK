// <copyright file="FiroozehGameService.cs" company="Firoozeh Technology LTD">
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
using FiroozehGameServiceAndroid.Builders;
using FiroozehGameServiceAndroid.Builders.App;
using FiroozehGameServiceAndroid.Builders.Native;
using FiroozehGameServiceAndroid.Enums;
using FiroozehGameServiceAndroid.Enums.GSLive;
using FiroozehGameServiceAndroid.Interfaces;
using FiroozehGameServiceAndroid.Utils;

/**
* @author Alireza Ghodrati
*/

namespace FiroozehGameServiceAndroid.Core
{
    
    #if UNITY_ANDROID
    public sealed class FiroozehGameService
    {
        private static Pair<Action,Action<string>> _actions;
        private const string Tag = "FiroozehGameService";

        public static GameService Instance { get; private set; }
        public static GameServiceClientConfiguration Configuration { get; private set; }

        
        public static void ConfigurationInstance(GameServiceClientConfiguration configuration)
        {  
            Configuration = configuration;     
        }

        public static void Run(Action connected,Action<string> onError)
        {
            if (Configuration == null)
            {
                LogUtil.LogError(Tag, "Configuration Not Set, Do Nothing..");
                return;
            }
            
            _actions = new Pair<Action, Action<string>>(connected,onError);
            
            if (Instance != null)
            {
                if(Configuration.EnableLog)
                LogUtil.LogWarning(Tag,"GameService Initialized Before , Do Nothing..");
                return;
            }

            if (Configuration.DownloadTag != null)
                GameServiceDownloadInitializer.DownloadData(Configuration,DownloadListener,DownloadErrorListener);
            else      
               GameServiceAppInitializer.Init(Configuration,OnSuccessInit,OnErrorInit);               
        }

        private static void DownloadListener(string callback)
        {
          GameServiceAppInitializer.Init(Configuration, OnSuccessInit, OnErrorInit);
        }
        
        private static void DownloadErrorListener(string error)
        {
          _actions.Second.Invoke(error);
        }
  
        private static void OnSuccessInit(GameService gameService)
        {
            Instance = gameService;
            _actions.First.Invoke();
            
            if(Configuration.EnableLog)
            LogUtil.LogDebug(Tag,"GameService Is Ready To Use!");
        }
        
        private static void OnErrorInit(string error)
        {
            if (Configuration.EnableLog)
            {
                if (error.Equals(CallbackList.GameServiceNotInstalled))
                    LogUtil.LogDebug(Tag, error + ",So Switching to Native Mode");
                else       
                    LogUtil.LogError(Tag, error);     
            }


            // Switch To Native Mode
            if (error.Equals(CallbackList.GameServiceInstallDialogDismiss)
                || error.Equals(CallbackList.GameServiceUpdateDialogDismiss)
                || error.Equals(CallbackList.GameServiceNotInstalled))
            {
                // Native Mode Call
                GameServiceNativeInitializer.Init(Configuration,OnSuccessInit,OnErrorInit);
            }
            else
            _actions.Second.Invoke(error);
        }

        public static void Login(LoginType loginType)
        {
            if (Instance == null)
            {
                LogUtil.LogError(Tag, "GameService Not Initialized Before , You Must Call \"Run\" Function...");
                return;
            }
            if (Instance.IsAvailable())
            {
                if (Configuration.EnableLog)
                    LogUtil.LogWarning(Tag, "GameService Initialized Before , You Must Logout First...");
                return;
            }

            Configuration.LoginType = loginType;
            GameServiceAppInitializer.Init(Configuration,OnSuccessInit,OnErrorInit);
        }
       
        public static void Logout(DelegateCore.IsUserLogout logout,DelegateCore.OnError error)
        {
            Instance.LogOut(logout.Invoke,error.Invoke);  
        }

    }  
    #endif
}
