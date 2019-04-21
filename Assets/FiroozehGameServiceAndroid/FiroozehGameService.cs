using System.Collections.Generic;
using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Interfaces;
using FiroozehGameServiceAndroid.Models;
using Newtonsoft.Json;
using UnityEngine;

namespace FiroozehGameServiceAndroid
{
    public sealed class FiroozehGameService {

        private readonly AndroidJavaObject _gameServiceObj;
        private readonly bool _haveNotification;

#if UNITY_ANDROID
        public FiroozehGameService(AndroidJavaObject gameService, bool haveNotification)
        {
            if (gameService != null)
            {
                _haveNotification = haveNotification;
                _gameServiceObj = gameService;
            }
            else throw new GameServiceException("GameServiceObj Is NULL");
        }

#endif

#if UNITY_ANDROID

        public void GetAchievements(DelegateCore.OnGetAchievement callback,DelegateCore.OnError error)
        {
            if (_gameServiceObj != null)
                _gameServiceObj.Call("GetAchievement"
                    , new IGameServiceCallback(Oncallback =>
                    {
                        callback.Invoke(JsonConvert.DeserializeObject<List<Achievement>>(Oncallback));
                 
                    }
                    , error.Invoke));
 
        }

#endif

#if UNITY_ANDROID
        public void UnlockAchievement(
            string achievementId, 
            DelegateCore.OnUnlockAchievement callback,
            DelegateCore.OnError error)
        {
            if (_gameServiceObj != null)
                _gameServiceObj.Call("UnlockAchievement"
                    , achievementId
                    ,_haveNotification
                    , new IGameServiceCallback(Oncallback => {
                        callback.Invoke(JsonConvert.DeserializeObject<Achievement>(Oncallback));
                    }
                    , error.Invoke));
            
        }

#endif
#if UNITY_ANDROID
        public void ShowAchievementsUI(DelegateCore.OnError error)
        {
            if (_gameServiceObj != null)
                _gameServiceObj.Call("ShowAchievementUI"
                    , new IGameServiceCallback(Oncallback => { }
                    , error.Invoke));
            
        }
#endif
#if UNITY_ANDROID

        public void ShowLeaderBoardsUI(DelegateCore.OnError error)
        {
            if (_gameServiceObj != null)
                _gameServiceObj.Call("ShowLeaderBoardUI"
                    , new IGameServiceCallback(Oncallback => { }

                    , error.Invoke));
            
        }
#endif
#if UNITY_ANDROID
        public void GetLeaderBoards(DelegateCore.OnGetLeaderBoards callback, DelegateCore.OnError error)
        {
            if (_gameServiceObj != null)
                _gameServiceObj.Call("GetLeaderBoards"
                    , new IGameServiceCallback(Oncallback => {
                        callback.Invoke(JsonConvert.DeserializeObject<List<LeaderBoard>>(Oncallback));
                    }
                    , error.Invoke));
            
        }
#endif
#if UNITY_ANDROID
        public void GetLeaderBoardDetails(
            string leaderBoardId,
            DelegateCore.OnGetLeaderBoardDetails callback,
            DelegateCore.OnError error)

        {
            if (_gameServiceObj != null)           
                _gameServiceObj.Call("GetLeaderBoardData"
                    , leaderBoardId
                    , new IGameServiceCallback(oncallback => {
                        callback.Invoke(JsonConvert.DeserializeObject<LeaderBoardDetails>(oncallback));
                    }, error.Invoke));
            
        }
#endif
#if UNITY_ANDROID
        public void SubmitScore(
            string leaderBoardId,
            int scoreValue,
            DelegateCore.OnCallback callback,
            DelegateCore.OnError error)

        {
            if (_gameServiceObj != null)
                _gameServiceObj.Call("SubmitScore"
                    , leaderBoardId
                    , scoreValue
                    ,_haveNotification
                    ,new IGameServiceCallback(callback.Invoke, error.Invoke));
            
        }
#endif
       
#if UNITY_ANDROID
        public void SaveGame(
             string saveGameName
            ,string saveGameDescription
            ,string saveGameCover
            ,object saveGameData
            , DelegateCore.OnCallback callback
            , DelegateCore.OnError error)
        {
            if (_gameServiceObj != null)
                _gameServiceObj.Call("SaveData"
                    , saveGameName
                    , saveGameDescription
                    , saveGameCover
                    , JsonConvert.SerializeObject(saveGameData)
                    , new IGameServiceCallback(callback.Invoke, error.Invoke));
            
        }
#endif
#if UNITY_ANDROID
        public void GetSaveGame<T>(DelegateCore.OnSaveGame<T>saveGameData, DelegateCore.OnError error)
        {
            if (_gameServiceObj != null)
                _gameServiceObj.Call("GetLastSave", new IGameServiceCallback( save =>
                {
                    saveGameData.Invoke(JsonConvert.DeserializeObject<T>(save));
                }, error.Invoke));
            
        }
#endif
        
#if UNITY_ANDROID
        public void GetSDKVersion(DelegateCore.OnCallback version, DelegateCore.OnError error)
        {
            if (_gameServiceObj != null)
                _gameServiceObj.Call("GetSDKVersion", new IGameServiceCallback(version.Invoke, error.Invoke));
            
        }

#endif

#if UNITY_ANDROID
        public void RemoveLastSave(DelegateCore.OnCallback saveGameData, DelegateCore.OnError error)
        {
            if (_gameServiceObj != null)
                _gameServiceObj.Call("RemoveLastSave", new IGameServiceCallback(saveGameData.Invoke, error.Invoke));
            
        }
#endif

#if UNITY_ANDROID
        public void GetUserData(DelegateCore.OnGetUserData saveGameData, DelegateCore.OnError error)
        {
            if (_gameServiceObj != null)
                _gameServiceObj.Call("GetUserData", new IGameServiceCallback(r =>
                {
                    saveGameData.Invoke(JsonConvert.DeserializeObject<User>(r));
                }, error.Invoke));
            
        }
#endif

      
#if UNITY_ANDROID

        public void ShowGamePageUi(DelegateCore.OnError error)
        {
            if (_gameServiceObj != null)
                _gameServiceObj.Call("ShowGamePageUI", new IGameServiceCallback(Oncallback => { }

                    , error.Invoke));
            
        }
#endif
        
#if UNITY_ANDROID

        public void ShowSurveyUi(DelegateCore.OnError error)
        {
            if (_gameServiceObj != null)
                _gameServiceObj.Call("ShowSurveyUI", new IGameServiceCallback(Oncallback => { }

                    , error.Invoke));
            
        }
#endif
        
#if UNITY_ANDROID

        public void DownloadObbData(
            string obbDataTag
            ,DelegateCore.OnCallback downloadCallback
            ,DelegateCore.OnError error)
        {
            if (_gameServiceObj != null)
                _gameServiceObj.Call("DownloadObbDataFile"
                    ,obbDataTag
                    , new IGameServiceCallback(downloadCallback.Invoke
                    , error.Invoke));
            
        }
#endif

    }
}
