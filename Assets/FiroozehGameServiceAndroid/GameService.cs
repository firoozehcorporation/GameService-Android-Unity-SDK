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
    #if UNITY_ANDROID
    public sealed class GameService
    {

        private const string Tag = "GameService";
        private readonly AndroidJavaObject _gameServiceObj;
        private readonly bool _haveNotification;
        private readonly GameServiceType _type;

        public GameService(AndroidJavaObject gameService, GameServiceType type ,bool haveNotification)
        {
            if (gameService != null)
            {
                _haveNotification = haveNotification;
                _gameServiceObj = gameService;
                _type = type;
            }
            else throw new GameServiceException("GameServiceObj Is NULL");
        }

        public void GetAchievements(DelegateCore.OnGetAchievement callback,DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
                return;
            }
                _gameServiceObj.Call("GetAchievements"
                    , new IGameServiceCallback(onCallback =>
                    {
                        callback.Invoke(JsonConvert.DeserializeObject<List<Achievement>>(onCallback));
                 
                    }
                    , error.Invoke));
 
        }

        public void UnlockAchievement(
            string achievementId, 
            DelegateCore.OnUnlockAchievement callback,
            DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
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

        public void ShowAchievementsUI(DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
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

        public void ShowLeaderBoardsUI(DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
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

        public void GetLeaderBoards(DelegateCore.OnGetLeaderBoards callback, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
                return;
            }
            
                _gameServiceObj.Call("GetLeaderBoards"
                    , new IGameServiceCallback(onCallback => {
                        callback.Invoke(JsonConvert.DeserializeObject<List<LeaderBoard>>(onCallback));
                    }
                    , error.Invoke));
            
        }

        
        public void GetLeaderBoardDetails(
            string leaderBoardId,
            DelegateCore.OnGetLeaderBoardDetails callback,
            DelegateCore.OnError error)

        {
            if (_gameServiceObj == null)
            {
                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
                return;
            }            
                _gameServiceObj.Call("GetLeaderBoardDetails"
                    , leaderBoardId
                    , new IGameServiceCallback(onCallback => {
                        callback.Invoke(JsonConvert.DeserializeObject<LeaderBoardDetails>(onCallback));
                    }, error.Invoke));
            
        }

        // Return LeaderBoard
        public void SubmitScore(
            string leaderBoardId,
            int scoreValue,
            DelegateCore.OnGetLeaderBoard callback,
            DelegateCore.OnError error)

        {
            if (_gameServiceObj == null)
            {
                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
                return;
            }            
                _gameServiceObj.Call("SubmitScore"
                    , leaderBoardId
                    , scoreValue
                    ,_haveNotification
                    ,new IGameServiceCallback(onCallback => { callback.Invoke(JsonConvert.DeserializeObject<LeaderBoard>(onCallback)); }, error.Invoke));
      
        }
       

        
        public void SaveGame(
             string saveGameName
            ,string saveGameDescription
            ,string saveGameCover
            ,object saveGameObj
            , DelegateCore.OnSaveGame<SaveDetails> callback
            , DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
                return;
            }
            
                _gameServiceObj.Call("SaveGame"
                    , saveGameName
                    , saveGameDescription
                    , saveGameCover
                    , JsonConvert.SerializeObject(saveGameObj)
                    , new IGameServiceCallback(onCallback =>
                    {
                        callback.Invoke(JsonConvert.DeserializeObject<SaveDetails>(onCallback));
                    }, error.Invoke));
            
        }

        public void GetSaveGame<T>(DelegateCore.OnSaveGame<T>saveGameData, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
                return;
            }
            
                _gameServiceObj.Call("GetLastSave", new IGameServiceCallback( save =>
                {
                    saveGameData.Invoke(JsonConvert.DeserializeObject<T>(save));
                }, error.Invoke));
            
        }


        public void GetAppVersion(DelegateCore.OnCallback version, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
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


        public void RemoveLastSave(DelegateCore.OnCallback saveGameData, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
                return;
            }
            
                _gameServiceObj.Call("RemoveLastSave", new IGameServiceCallback(saveGameData.Invoke, error.Invoke));
            
        }

        
        public void GetUserData(DelegateCore.OnGetUserData saveGameData, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
                return;
            }
            
                _gameServiceObj.Call("GetUserData", new IGameServiceCallback(r =>
                {
                    saveGameData.Invoke(JsonConvert.DeserializeObject<User>(r));
                }, error.Invoke));
            
        }


        public void ShowGamePageUI(DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
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


        public void ShowSurveyUI(DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
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


        public void DownloadObbData(
            string obbDataTag
            ,DelegateCore.OnCallback downloadCallback
            ,DelegateCore.OnError error)
        {
            if (_gameServiceObj == null)
            {
                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GameService Is NotAvailable yet");
                return;
            }
            
              _gameServiceObj.Call("DownloadObbDataFile"
                    ,obbDataTag
                    , new IGameServiceCallback(downloadCallback.Invoke
                    , error.Invoke));
            
        }
    }
    #endif
}
