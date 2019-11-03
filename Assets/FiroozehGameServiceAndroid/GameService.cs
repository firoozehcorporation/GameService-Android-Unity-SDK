// <copyright file="GameService.cs" company="Firoozeh Technology LTD">
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
using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Core.GSLive;
using FiroozehGameServiceAndroid.Enums;
using FiroozehGameServiceAndroid.Interfaces;
using FiroozehGameServiceAndroid.Models;
using FiroozehGameServiceAndroid.Utils;
using Newtonsoft.Json;
using UnityEngine;

/**
* @author Alireza Ghodrati
*/


namespace FiroozehGameServiceAndroid
{
    /// <summary>
    /// Represents GameService Main Class In GameService System
    /// </summary>
    #if UNITY_ANDROID
    public class GameService 
    {
        private const string Tag = "GameService";
        private AndroidJavaObject _gameServiceObj;
        private bool _isAvailable ;
        private readonly bool _haveNotification;
        private readonly GameServiceType _type;
        
        public GSLive GSLive { get; private set; }


        public GameService(AndroidJavaObject gameService, GameServiceType type ,bool haveNotification)
        {
            if (gameService != null)
            {
                _haveNotification = haveNotification;
                _gameServiceObj = gameService;
                _type = type;
                _isAvailable = true;
                GSLive = new GSLive();
            }
            else throw new GameServiceException("GameServiceObj Is NULL");
        }

        
        
        /// <summary>
        /// With this command you can get  list of all your game LeaderBoard
        /// that you have registered in the Developer panel
        /// </summary>
        /// <param name="callback">List of LeaderBoard <see cref="DelegateCore.OnGetLeaderBoards"/></param>
        /// <param name="error">Error</param>
        public void GetLeaderBoards(DelegateCore.OnGetLeaderBoards callback, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            
            _gameServiceObj.Call("GetLeaderBoards"
                , new IGameServiceCallback(onCallback => {
                        callback.Invoke(JsonConvert.DeserializeObject<List<LeaderBoard>>(onCallback));
                    }
                    , error.Invoke));
            
        }

        
        
        
        /// <summary>
        /// With this command you can get list of all your game achievements
        /// that you have registered in the Developer panel.
        /// </summary>
        /// <param name="callback">List of achievements <see cref="DelegateCore.OnGetAchievement"/></param>
        /// <param name="error">Error</param>
        public void GetAchievements(DelegateCore.OnGetAchievement callback,DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
               
            _gameServiceObj.Call("GetAchievements"
                    , new IGameServiceCallback(onCallback =>
                    {
                        callback.Invoke(JsonConvert.DeserializeObject<List<Achievement>>(onCallback));
                 
                    }
                    , error.Invoke));
 
        }

        
        
        
        /// <summary>
        /// With this command you can save your Current Status in Game
        /// </summary>
        /// <param name="saveGameName">saveGameName</param>
        /// <param name="saveGameDescription">saveGameDescription</param>
        /// <param name="saveGameObj">the Object that you Want To Save it</param>
        /// <param name="callback">Your Save Object <see cref="DelegateCore.OnSaveGame{T}"/>></param>
        /// <param name="error">Error</param>
        public void SaveGame(
            string saveGameName
            ,string saveGameDescription
            ,object saveGameObj
            , DelegateCore.OnSaveGame<SaveDetails> callback
            , DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            
            _gameServiceObj.Call("SaveGame"
                , saveGameName
                , saveGameDescription
                , JsonConvert.SerializeObject(saveGameObj)
                , new IGameServiceCallback(onCallback =>
                {
                    callback.Invoke(JsonConvert.DeserializeObject<SaveDetails>(onCallback));
                }, error.Invoke));
            
        }
        
        
        
        
        /// <summary>
        /// This command allows you to Submit Player Score with the ID of the leaderBoard
        /// you have Registered in the Developer panel
        /// </summary>
        /// <param name="leaderBoardId">leaderBoardId</param>
        /// <param name="scoreValue">scoreValue(The value must not exceed the maximum value Registered in the Developer Panel)</param>
        /// <param name="callback">Get LeaderBoard <see cref="DelegateCore.OnGetLeaderBoard"/>></param>
        /// <param name="error">Error</param>
        public void SubmitScore(
            string leaderBoardId,
            int scoreValue,
            DelegateCore.OnGetLeaderBoard callback,
            DelegateCore.OnError error)

        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            _gameServiceObj.Call("SubmitScore"
                , leaderBoardId
                , scoreValue
                ,_haveNotification
                ,new IGameServiceCallback(onCallback => { callback.Invoke(JsonConvert.DeserializeObject<LeaderBoard>(onCallback)); }, error.Invoke));
      
        }
        
        
        
        /// <summary>
        /// With this command you can Unlock achievement with the achievement ID
        /// you registered in the Developer panel.
        /// </summary>
        /// <param name="achievementId">The ID of Achievement you Want To Unlock it</param>
        /// <param name="callback"> Unlock Achievement Object<see cref="DelegateCore.OnUnlockAchievement"/></param>
        /// <param name="error">Error</param>
        public void UnlockAchievement(
            string achievementId, 
            DelegateCore.OnUnlockAchievement callback,
            DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }               
       
            _gameServiceObj.Call("UnlockAchievement"
                    , achievementId
                    ,_haveNotification
                    , new IGameServiceCallback(onCallback => {
                        callback.Invoke(JsonConvert.DeserializeObject<Achievement>(onCallback));
                    }
                    , error.Invoke));
            
        }

        
        
        
        
        /// <summary>
        /// This command will get you the last save you saved
        /// </summary>
        /// <param name="saveGameData">Your Save Object<see cref="DelegateCore.OnSaveGame{T}"/></param>
        /// <param name="error">Error</param>
        public void GetSaveGame<T>(DelegateCore.OnSaveGame<T>saveGameData, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            _gameServiceObj.Call("GetLastSave", new IGameServiceCallback( save =>
            {
                saveGameData.Invoke(JsonConvert.DeserializeObject<T>(save));
            }, error.Invoke));
            
        }

        
        
        
        /// <summary>
        /// With this command you can get a LeaderBoardDetails with the ID of the LeaderBoard list
        /// you registered in the Developer panel.
        /// </summary>
        /// <param name="leaderBoardId">The ID of leaderBoard you Want To get Detail</param>
        /// <param name="callback">LeaderBoardDetails<see cref="DelegateCore.OnGetLeaderBoardDetails"/></param>
        /// <param name="error">Error</param>
        public void GetLeaderBoardDetails(
            string leaderBoardId,
            DelegateCore.OnGetLeaderBoardDetails callback,
            DelegateCore.OnError error)

        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            _gameServiceObj.Call("GetLeaderBoardDetails"
                , leaderBoardId
                , new IGameServiceCallback(onCallback => {
                    callback.Invoke(JsonConvert.DeserializeObject<LeaderBoardDetails>(onCallback));
                }, error.Invoke));
            
        }

        
        
        /// <summary>
        /// With this command you can Show the achievements list
        /// NOTE : This Command Only Available in App Mode
        /// </summary>
        /// <param name="error">Error</param>
        public void ShowAchievementsUi(DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            if (_type == GameServiceType.Native)
            {

                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"ShowAchievementsUI Only Available In AppMode");
                return;
            }

            _gameServiceObj.Call("ShowAchievementUI"
                , new IGameServiceCallback(onCallback => { }
                    , error.Invoke));

        }

        
        
        /// <summary>
        /// With this command you can Show LeaderBoard list
        /// NOTE : This Command Only Available in App Mode
        /// </summary>
        /// <param name="error">Error</param>
        public void ShowLeaderBoardsUi(DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            if (_type == GameServiceType.Native)
            {

                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"ShowLeaderBoardsUI Only Available In AppMode");
                return;
            }
            
                _gameServiceObj.Call("ShowLeaderBoardUI"
                    , new IGameServiceCallback(onCallback => { }

                    , error.Invoke));
                    
            
        }


      
        
        /// <summary>
        /// With this command you can get the current version of the game service application
        /// </summary>
        /// <param name="version">the current version of the game service application</param>
        /// <param name="error">Error</param>
        public void GetAppVersion(DelegateCore.OnCallback version, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            if (_type == GameServiceType.Native)
            {

                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GetSDKVersion Only Available In AppMode");
                return;
            }

                _gameServiceObj.Call("GetSDKVersion", new IGameServiceCallback(version.Invoke, error.Invoke));
            
        }


        
        
        
        /// <summary>
        /// With this command you can get information about the current player is playing
        /// </summary>
        /// <param name="saveGameData">the current player is playing<see cref="DelegateCore.OnGetUserData"/></param>
        /// <param name="error">Error</param>
        public void GetUserData(DelegateCore.OnGetUserData saveGameData, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            
            _gameServiceObj.Call("GetUserData", new IGameServiceCallback(r =>
            {
                saveGameData.Invoke(JsonConvert.DeserializeObject<User>(r));
            }, error.Invoke));
            
        }

        
        
        /// <summary>
        /// This command can remove the last current user saved
        /// </summary>
        /// <param name="removeSave">removeSave Result ("Done" if Successful)</param>
        /// <param name="error">Error</param>
        public void RemoveLastSave(DelegateCore.OnCallback removeSave, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
                _gameServiceObj.Call("RemoveLastSave", new IGameServiceCallback(removeSave.Invoke, error.Invoke));
            
        }

        
        /// <summary>
        /// This will open the Survey page for Current game
        /// NOTE : This Command Only Available in App Mode
        /// </summary>
        /// <param name="error">Error</param>
        public void ShowSurveyUi(DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            
            if (_type == GameServiceType.Native)
            {

                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"ShowSurveyUi Only Available In AppMode");
                return;
            }
            
            _gameServiceObj.Call("ShowSurveyUI", new IGameServiceCallback(onCallback => { }

                , error.Invoke));
            
        }



        
        /// <summary>
        /// With this command Current game page opens in the game service app
        /// NOTE : This Command Only Available in App Mode
        /// </summary>
        /// <param name="error">Error</param>
        public void ShowGamePageUi(DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            if (_type == GameServiceType.Native)
            {

                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"ShowGamePageUI Only Available In AppMode");
                return;
            }
            
                _gameServiceObj.Call("ShowGamePageUI", new IGameServiceCallback(onCallback => { }

                    , error.Invoke));
            
        }


        
        /// <summary>
        /// This command will return all information about the bucket with a specific ID
        /// </summary>
        /// <param name="bucketId">The ID of Bucket you Want To get Detail</param>
        /// <param name="onBucketItems">All items in a bucket<see cref="DelegateCore.OnBucketItems{TBucket}"/></param>
        /// <param name="error">Error</param>
        public void GetBucketItems<TBucket>(string bucketId , DelegateCore.OnBucketItems<TBucket> onBucketItems, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            
            _gameServiceObj.Call("GetAllBucketData",bucketId, new IGameServiceCallback(r =>
            {
                onBucketItems.Invoke(JsonConvert.DeserializeObject<List<TBucket>>(r));
            }, error.Invoke));
            
        }
              
        
        
        
        /// <summary>
        /// This command returns one of the Specific bucket information with a specific ID
        /// </summary>
        /// <param name="bucketId">The ID of Bucket you Want To get Detail</param>
        /// <param name="itemId">The ID of BucketItem you Want To get Detail</param>
        /// <param name="error">Error</param>
        public void GetBucketItem<TBucket>(string bucketId ,string itemId, DelegateCore.OnBucketItem<TBucket> onBucketItem, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            _gameServiceObj.Call("GetOneBucketData",bucketId,itemId, new IGameServiceCallback(r =>
            {
                onBucketItem.Invoke(JsonConvert.DeserializeObject<Bucket<TBucket>>(r));
            }, error.Invoke));
            
        }
             
        
        
        /// <summary>
        /// This command will edit one of the bucket information with a specific ID
        /// </summary>
        /// <param name="bucketId">The ID of Bucket you Want To Edit Details</param>
        /// <param name="itemId">The ID of BucketItem you Want To Edit Details</param>
        /// <param name="editedBucket">The Object of BucketItem you Want To Edit Detail</param>
        /// <param name="error">Error</param>
        public void UpdateBucketItem<TBucket>(string bucketId ,string itemId, TBucket editedBucket, DelegateCore.OnUpdateBucketItem<TBucket> onUpdateBucketItem, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            _gameServiceObj.Call("UpdateOneBucketData",
                bucketId, itemId , JsonConvert.SerializeObject(editedBucket)
                , new IGameServiceCallback(r =>
            {
                onUpdateBucketItem.Invoke(JsonConvert.DeserializeObject<Bucket<TBucket>>(r));
            }, error.Invoke));
            
        }

        
        
        /// <summary>
        /// This command will Add new bucket information with a specific ID
        /// </summary>
        /// <param name="bucketId">The ID of Bucket you Want To Add Item</param>
        /// <param name="newBucket">The Object of BucketItem you Want To Add</param>
        /// <param name="onAddBucketItem">The Object of BucketItem you Added <see cref="DelegateCore.OnAddBucketItem{TBucket}"/></param>
        /// <param name="error">Error</param>
        public void AddBucketItem<TBucket>(string bucketId, TBucket newBucket, DelegateCore.OnAddBucketItem<TBucket> onAddBucketItem, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            
            _gameServiceObj.Call("AddNewBucketData",bucketId , JsonConvert.SerializeObject(newBucket)
                , new IGameServiceCallback(r =>
            {
                onAddBucketItem.Invoke(JsonConvert.DeserializeObject<Bucket<TBucket>>(r));
            }, error.Invoke));
            
        }
        
        
        
        
        /// <summary>
        /// This command will delete one of the bucket information with a specific ID
        /// </summary>
        /// <param name="bucketId">The ID of Bucket you Want To Delete one of Items</param>
        /// <param name="itemId">The ID of BucketItem you Want To Delete it</param>
        /// <param name="onDeleteBucket">The Result of BucketItem you Deleted (Return True if Successful) <see cref="DelegateCore.OnDeleteBucket"/></param>
        /// <param name="error">Error</param>
        public void DeleteBucketItem(string bucketId ,string itemId, DelegateCore.OnDeleteBucket onDeleteBucket, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            _gameServiceObj.Call("DeleteOneBucket",bucketId,itemId, new IGameServiceCallback(r =>
            {
                onDeleteBucket.Invoke(bool.Parse(r));
            }, error.Invoke));
            
        }

        
        
        /// <summary>
        /// This command will delete All of the bucket Items information with a specific ID
        /// </summary>
        /// <param name="bucketId">The ID of Bucket you Want To Delete All Items</param>
        /// <param name="onDeleteBucket">The Result of BucketItems you Deleted (Return True if Successful) <see cref="DelegateCore.OnDeleteBucket"/></param>
        /// <param name="error">Error</param>
        public void DeleteBucketItems(string bucketId, DelegateCore.OnDeleteBucket onDeleteBucket, DelegateCore.OnError error)
        {  
            
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
            
            _gameServiceObj.Call("DeleteAllBucketData",bucketId, new IGameServiceCallback(r =>
            {
                onDeleteBucket.Invoke(bool.Parse(r));
            }, error.Invoke));
            
        }
        
        
        
        
        /// <summary>
        /// This command is used to login again or login from guest mode to normal or vice versa
        /// </summary>
        /// <param name="logout">return true if Successful</param>
        /// <param name="error">Error</param>
        public void LogOut(DelegateCore.IsUserLogout logout ,DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if (_isAvailable)
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "GameService Is NotAvailable yet");
                }
                else
                {
                    if (FiroozehGameService.Configuration.EnableLog)
                        LogUtil.LogError(Tag, "You Logout Before ,You Must Config it Again...");
                }
                return;
            }
       
            _gameServiceObj.Call("Logout",new IGameServiceCallback(c =>
            {
                _gameServiceObj = null;
                _isAvailable = false;
                logout.Invoke(true);
            },error.Invoke));
        }

        
        /// <summary>
        /// get Game Service Status
        /// </summary>
        public bool IsAvailable()
        {
            return _isAvailable;
        }
    }
    
    #endif
}
