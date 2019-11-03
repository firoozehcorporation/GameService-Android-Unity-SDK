// <copyright file="DelegateCore.cs" company="Firoozeh Technology LTD">
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

using System.Collections.Generic;
using FiroozehGameServiceAndroid.Models;
using UnityEngine;

/**
* @author Alireza Ghodrati
*/

namespace FiroozehGameServiceAndroid.Core
{
    #if UNITY_ANDROID
    /// <summary>
    /// Represents Game Service DelegateCore
    /// </summary>
    public static class DelegateCore {

        public delegate void OnSuccessInit(AndroidJavaObject gameServiceObj);

        public delegate void OnSuccessInitService(GameService builder);

        public delegate void OnCallback(string result);
        public delegate void OnError(string error);

        public delegate void IsUserLogin(bool status);
        public delegate void IsUserLogout(bool status);

        
        public delegate void OnSaveGame<in T>(T result);



        public delegate void OnGetAchievement(List<Achievement>achievements);
        public delegate void OnUnlockAchievement(Achievement unlockedObj);


        public delegate void OnGetLeaderBoards(List<LeaderBoard> leaderBoards);
        public delegate void OnGetLeaderBoard(LeaderBoard leaderBoard);
        public delegate void OnGetLeaderBoardDetails(LeaderBoardDetails leaderBoardDetails);



        public delegate void OnGetUserData(User user);
       

        public delegate void JsonData(string jsonData);
        public delegate void NotificationListener(string jsonData);


        public delegate void OnBucketItems<TBucket>(List<TBucket> buckets);
        public delegate void OnBucketItem<TBucket>(Bucket<TBucket> bucket);
        public delegate void OnUpdateBucketItem<TBucket>(Bucket<TBucket> bucket);
        public delegate void OnAddBucketItem<TBucket>(Bucket<TBucket> bucket);
        public delegate void OnDeleteBucket(bool isDeleted);


        public delegate void OnEvent(int type,string payLoad);




    }
    #endif
}
