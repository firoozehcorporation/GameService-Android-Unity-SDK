using System.Collections.Generic;
using FiroozehGameServiceAndroid.Models;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Core
{
    public static class DelegateCore {

        public delegate void OnSuccessInit(AndroidJavaObject gameServiceObj);

        public delegate void OnSuccessInitService(FiroozehGameService builder);

        public delegate void OnCallback(string result);
        public delegate void OnError(string error);

        public delegate void IsUserLogin(bool status);
        
        public delegate void OnSaveGame<in T>(T result);



        public delegate void OnGetAchievement(List<Achievement>achievements);
        public delegate void OnUnlockAchievement(Achievement unlockedObj);


        public delegate void OnGetLeaderBoards(List<LeaderBoard> leaderBoards);
        public delegate void OnGetLeaderBoardDetails(LeaderBoardDetails leaderBoardDetails);



        public delegate void OnGetUserData(User user);

    }
}
