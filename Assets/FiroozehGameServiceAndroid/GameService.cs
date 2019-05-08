using System.Collections.Generic;
using FiroozehGameServiceAndroid.Builders;
using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Enums;
using FiroozehGameServiceAndroid.Interfaces;
using FiroozehGameServiceAndroid.Interfaces.App;
using FiroozehGameServiceAndroid.Models;
using FiroozehGameServiceAndroid.Utils;
using Newtonsoft.Json;
using UnityEngine;

namespace FiroozehGameServiceAndroid
{
    public sealed class GameService
    {

        private const string Tag = "GameService";
        private readonly AndroidJavaObject _gameServiceObj;
        private readonly bool _haveNotification;
        private readonly GameServiceType _type;

#if UNITY_ANDROID
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
            if (_gameServiceObj == null) return;
            if (_type == GameServiceType.Native)
            {

                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"ShowAchievementsUI Only Available In AppMode");
                return;
            }

            _gameServiceObj.Call("ShowAchievementUI"
                , new IGameServiceCallback(oncallback => { }
                    , error.Invoke));

        }
#endif
#if UNITY_ANDROID

        public void ShowLeaderBoardsUI(DelegateCore.OnError error)
        {
            if (_gameServiceObj == null) return;
            if (_type == GameServiceType.Native)
            {

                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"ShowLeaderBoardsUI Only Available In AppMode");
                return;
            }
            
                _gameServiceObj.Call("ShowLeaderBoardUI"
                    , new IGameServiceCallback(oncallback => { }

                    , error.Invoke));
            
        }
#endif
#if UNITY_ANDROID
        public void GetLeaderBoards(DelegateCore.OnGetLeaderBoards callback, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null) return;
            
                _gameServiceObj.Call("GetLeaderBoards"
                    , new IGameServiceCallback(oncallback => {
                        callback.Invoke(JsonConvert.DeserializeObject<List<LeaderBoard>>(oncallback));
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
            if (_gameServiceObj == null) return;    
            
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
            if (_gameServiceObj == null) return;
            
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
            if (_gameServiceObj == null) return;
            
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
            if (_gameServiceObj == null) return;
            
                _gameServiceObj.Call("GetLastSave", new IGameServiceCallback( save =>
                {
                    saveGameData.Invoke(JsonConvert.DeserializeObject<T>(save));
                }, error.Invoke));
            
        }
#endif
        
#if UNITY_ANDROID
        public void GetSDKVersion(DelegateCore.OnCallback version, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null) return;
            if (_type == GameServiceType.Native)
            {

                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"GetSDKVersion Only Available In AppMode");
                return;
            }

                _gameServiceObj.Call("GetSDKVersion", new IGameServiceCallback(version.Invoke, error.Invoke));
            
        }

#endif

#if UNITY_ANDROID
        public void RemoveLastSave(DelegateCore.OnCallback saveGameData, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null) return;
            
                _gameServiceObj.Call("RemoveLastSave", new IGameServiceCallback(saveGameData.Invoke, error.Invoke));
            
        }
#endif

#if UNITY_ANDROID
        public void GetUserData(DelegateCore.OnGetUserData saveGameData, DelegateCore.OnError error)
        {
            if (_gameServiceObj == null) return;
            
                _gameServiceObj.Call("GetUserData", new IGameServiceCallback(r =>
                {
                    saveGameData.Invoke(JsonConvert.DeserializeObject<User>(r));
                }, error.Invoke));
            
        }
#endif

      
#if UNITY_ANDROID

        public void ShowGamePageUi(DelegateCore.OnError error)
        {
            if (_gameServiceObj == null) return;
            if (_type == GameServiceType.Native)
            {

                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"ShowGamePageUi Only Available In AppMode");
                return;
            }
            
                _gameServiceObj.Call("ShowGamePageUI", new IGameServiceCallback(Oncallback => { }

                    , error.Invoke));
            
        }
#endif
        
#if UNITY_ANDROID

        public void ShowSurveyUi(DelegateCore.OnError error)
        {
            if (_gameServiceObj == null) return;
            if (_type == GameServiceType.Native)
            {

                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"ShowSurveyUi Only Available In AppMode");
                return;
            }
            
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
            if (_gameServiceObj == null) return;
            if (_type == GameServiceType.Native)
            {

                if(FiroozehGameService.Configuration.EnableLog)
                    LogUtil.LogError(Tag,"DownloadObbData Only Available In AppMode");
                return;
            }

            
                _gameServiceObj.Call("DownloadObbDataFile"
                    ,obbDataTag
                    , new IGameServiceCallback(downloadCallback.Invoke
                    , error.Invoke));
            
        }
#endif

    }
}
