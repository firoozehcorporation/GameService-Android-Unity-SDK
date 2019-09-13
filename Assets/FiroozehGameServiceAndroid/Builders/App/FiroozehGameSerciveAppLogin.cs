// <copyright file="FiroozehGameServiceAppLoginCheck.cs" company="Firoozeh Technology LTD">
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
using FiroozehGameServiceAndroid.Core.App;
using FiroozehGameServiceAndroid.Interfaces.App;


/**
* @author Alireza Ghodrati
*/

namespace FiroozehGameServiceAndroid.Builders.App
{
#if UNITY_ANDROID
    public static class FiroozehGameServiceAppLoginCheck
    {
        public static void CheckUserLoginStatus(
             bool checkAppStatus
            ,bool checkOptionalUpdate
             ,bool isLogEnable
            ,DelegateCore.IsUserLogin userLogin
            , DelegateCore.OnError error)
        {

     
            AppPluginHandler.InitGameLoginService(
                 checkAppStatus
                ,checkOptionalUpdate
                 ,isLogEnable
                ,s=>
                {
                        s.Call("IsUserLoggedIn",
                            new IGameServiceLoginCheck(
                                userLogin.Invoke
                              , error.Invoke)); 
                } , error.Invoke);
        
        }
        public static void ShowLoginUI(
            bool checkAppStatus
            ,bool checkOptionalUpdate  
            ,bool isLogEnable
            ,DelegateCore.IsUserLogin isUserLogin
            ,DelegateCore.OnError error)
        {

           AppPluginHandler.InitGameLoginService(checkAppStatus,checkOptionalUpdate,isLogEnable
                ,s =>
                {
                    s.Call("ShowLoginUI",
                        new IGameServiceLoginCheck(
                        isUserLogin.Invoke, error.Invoke));
                }
                , error.Invoke);

     
        }
    }
#endif

}
