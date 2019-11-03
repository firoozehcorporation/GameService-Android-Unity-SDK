// <copyright file="IGameServiceLoginCheck.cs" company="Firoozeh Technology LTD">
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

namespace FiroozehGameServiceAndroid.Interfaces.App
{
#if UNITY_ANDROID
    /// <summary>
    /// Represents GameService Internal interface
    /// </summary>
    public class IGameServiceLoginCheck : AndroidJavaProxy
    {

        private readonly DelegateCore.IsUserLogin _UserLogin;
        private readonly DelegateCore.OnError _OnError;

        public IGameServiceLoginCheck(DelegateCore.IsUserLogin isUserLoggedIn, DelegateCore.OnError onError)
            : base("ir.firoozehcorp.gameservice.android.unity.App.Interfaces.IGameServiceLoginCheck")
        {
            _UserLogin = isUserLoggedIn;
            _OnError = onError;
        }

        public void isLoggedIn(bool Status)
        {
            _UserLogin.Invoke(Status);
        }

        public void OnError(string Error)
        {
            _OnError.Invoke(Error);
        }
    }
#endif
}
