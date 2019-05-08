// <copyright file="LogUtil.cs" company="Firoozeh Technology LTD">
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



using FiroozehGameServiceAndroid.Core;
using UnityEngine;

/**
* @author Alireza Ghodrati
*/


namespace FiroozehGameServiceAndroid.Utils
{
    public sealed class LogUtil
    {
        private const string Tag = "FiroozehGameServiceLogUtil";
        private static bool _isLogEnable;

        public static void InitialLogger(GameServiceClientConfiguration configuration)
        {
            _isLogEnable = configuration.EnableLog;
        }

        public static void LogDebug(string where,string debug)
        {
            if(_isLogEnable)
                Debug.unityLogger.Log(where,debug);
        }
        
        public static void LogWarning(string where,string warning)
        {
            if(_isLogEnable)
            Debug.unityLogger.LogWarning(where,warning);
        }

        public static void LogError(string where,string error)
        {
            if(_isLogEnable)
            Debug.unityLogger.LogWarning(where,error);
        }
    }
}