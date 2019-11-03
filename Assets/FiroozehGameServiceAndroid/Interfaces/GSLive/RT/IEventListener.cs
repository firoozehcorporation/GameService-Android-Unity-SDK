// <copyright file="IEventListener.cs" company="Firoozeh Technology LTD">
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

namespace FiroozehGameServiceAndroid.Interfaces.GSLive.RT
{
#if UNITY_ANDROID
    /// <summary>
    /// Represents GameService RealTime Internal interface
    /// </summary>
    public class IEventListener : AndroidJavaProxy
    {
        private readonly DelegateCore.OnEvent _event;
        private readonly DelegateCore.OnError _error;
        
        public IEventListener(DelegateCore.OnEvent Event,DelegateCore.OnError error) 
            : base("ir.firoozehcorp.gameservice.android.unity.GSLive.RT.Interfaces.RTEventListener")
        {
            _event = Event;
            _error = error;    
        }

        void OnEvent(int type , string payload)
        {
            _event.Invoke(type,payload);
        }

        void OnError(string error)
        {
            _error.Invoke(error);
        }
     
    }
#endif
}