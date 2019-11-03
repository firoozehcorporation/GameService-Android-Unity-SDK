// <copyright file="GSLiveProvider.cs" company="Firoozeh Technology LTD">
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


namespace FiroozehGameServiceAndroid.Core.GSLive
{
#if UNITY_ANDROID
    public static class GSLiveProvider
    {
        /// <summary>
        /// Represents GSLive Provider 
        /// </summary>
        public static AndroidJavaObject GetGSLiveRT()
        {
            var gsLive = new AndroidJavaClass("ir.firoozehcorp.gameservice.android.unity.GSLive.RT.Handlers.GSLiveRTHandler");
            return gsLive.CallStatic<AndroidJavaObject>("GetInstance");
        } 
        
        public static AndroidJavaObject GetGSLiveTB()
        {
            var gsLive = new AndroidJavaClass("ir.firoozehcorp.gameservice.android.unity.GSLive.TB.Handlers.GSLiveTBHandler");
            return gsLive.CallStatic<AndroidJavaObject>("GetInstance");
        } 
        
        public static AndroidJavaObject GetGSLiveChat()
        {
            var gsLive = new AndroidJavaClass("ir.firoozehcorp.gameservice.android.unity.Command.Handlers.ChatHandlers");
            return gsLive.CallStatic<AndroidJavaObject>("GetInstance");
        }    
    }
#endif
}