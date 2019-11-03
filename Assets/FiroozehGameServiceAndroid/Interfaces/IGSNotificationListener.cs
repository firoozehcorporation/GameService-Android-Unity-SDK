// <copyright file="IGSNotificationListener.cs" company="Firoozeh Technology LTD">
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


namespace FiroozehGameServiceAndroid.Interfaces
{
#if UNITY_ANDROID
    /// <summary>
    /// Represents GameService Notification Internal interface
    /// </summary>
    public class IGSNotificationListener : AndroidJavaProxy
    {
        private readonly DelegateCore.JsonData _onData;
        
        public IGSNotificationListener(DelegateCore.JsonData onData) 
            : base("ir.firoozehcorp.gameservice.android.unity.Native.Interfaces.NotificationListener")
        {
            _onData = onData;
        }


        void onData(string JsonData)
        {
            _onData.Invoke(JsonData);
        }
      
    }
#endif
}