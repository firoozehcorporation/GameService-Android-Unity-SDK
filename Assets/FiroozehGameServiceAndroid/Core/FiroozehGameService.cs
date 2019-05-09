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
using FiroozehGameServiceAndroid.Utils;

/**
* @author Alireza Ghodrati
*/

namespace FiroozehGameServiceAndroid.Core
{
    
    #if UNITY_ANDROID
    public sealed class FiroozehGameService
    {

        private static GameService _instance;
        private static Pair<Action,Action<string>> _actions;
        private const string Tag = "FiroozehGameService";


        public static void ConfigurationInstance(GameServiceClientConfiguration configuration)
        {  
            Configuration = configuration;     
        }

        public static void Run(Action connected,Action<string> onError)
        {
            _actions = new Pair<Action, Action<string>>(connected,onError);
            
            if (_instance != null)
            {
                if(Configuration.EnableLog)
                LogUtil.LogWarning(Tag,"GameService Initialized Before , Do Nothing..");
                return;
            }

            switch (Configuration.InstanceType)
            {
             
                case InstanceType.Native:
                    GameServiceNativeInitializer.Init(Configuration,OnSuccessInit,OnErrorInit);
                    break;
                case InstanceType.Auto:
                    GameServiceAppInitializer.Init(Configuration,OnSuccessInit,OnErrorInit);       
                    break;
                default:
                    if(Configuration.EnableLog)
                    LogUtil.LogError(Tag,"Invalid Instance Type , Auto Type Selected...");
                   
                    GameServiceAppInitializer.Init(Configuration,OnSuccessInit,OnErrorInit);       
                    break;
            }
             
         
        }

        private static void OnSuccessInit(GameService gameService)
        {
            _instance = gameService;
            _actions.First.Invoke();
            
            if(Configuration.EnableLog)
            LogUtil.LogDebug(Tag,"GameService Is Ready To Use!");
        }
        
        private static void OnErrorInit(string error)
        {
            if(Configuration.EnableLog)
            LogUtil.LogError(Tag,error);
            
            
            // Switch To Native Mode
            if (error.Equals(ErrorList.GameServiceInstallDialogDismiss)
                || error.Equals(ErrorList.GameServiceUpdateDialogDismiss)
                || error.Equals(ErrorList.GameServiceNotInstalled))
            {
                // Native Mode Call
                GameServiceNativeInitializer.Init(Configuration,OnSuccessInit,OnErrorInit);
            }
            else
            _actions.Second.Invoke(error);
        }
        

        public static GameService Instance
        {
            get
            {
                if (_instance == null)
                    if(Configuration.EnableLog)
                        LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
                
                return _instance;
            }
        }
   

        public static GameServiceClientConfiguration Configuration { get; private set; }
    }
    
    
    
    #endif
}
