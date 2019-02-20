using FiroozehGameServiceAndroid.Interfaces;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Core
{
    public sealed class GameServicePluginHandler {

#if UNITY_ANDROID
        private static AndroidJavaObject GetGameServiceInstance()
        {
            var GameService = PluginProvider.GetGameService();
            var UnityActivity = PluginProvider.GetUnityActivity();

            GameService.Call("SetUnityContext", UnityActivity);

            return GameService;
        }
#endif

#if UNITY_ANDROID
        private static AndroidJavaObject GetGameLoginServiceInstance()
        {
            var LoginService = PluginProvider.GetLoginService();
            var UnityActivity = PluginProvider.GetUnityActivity();

            LoginService.Call("SetUnityContext", UnityActivity);

            return LoginService;
        }
#endif

#if UNITY_ANDROID
        public static AndroidJavaObject InitGameService(string ClientId,string ClientSecret,DelegateCore.OnSuccessInit onSuccess, DelegateCore.OnError onError)
        {
   
            var gameService = GetGameServiceInstance();

            gameService.Call("InitGameService", ClientId, ClientSecret,
                new GameServiceCallback(CallBack => {
                        if(CallBack.Equals("Success"))
                            onSuccess.Invoke(gameService);
                    },
                    OnError =>
                    {
                        onError.Invoke(OnError);
                    }));

            return gameService;
        }

#endif

#if UNITY_ANDROID

        public static void InitGameLoginService(DelegateCore.OnSuccessInit onSuccess, DelegateCore.OnError onError)
        {

            var loginService = GetGameLoginServiceInstance();

            loginService.Call("InitLoginService",
                new GameServiceCallback(CallBack => {
                        if (CallBack.Equals("Success"))
                            onSuccess.Invoke(loginService);
                    },
                    OnError =>
                    {
                        onError.Invoke(OnError);
                    }));

            return;
        }

#endif



    }
}
