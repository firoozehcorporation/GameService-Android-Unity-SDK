using FiroozehGameServiceAndroid.Interfaces;
using FiroozehGameServiceAndroid.Interfaces.App;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Core.App
{
    public static class AppPluginHandler {

#if UNITY_ANDROID
        private static AndroidJavaObject GetGameServiceInstance()
        {
            var gameService = AppPluginProvider.GetGameService();
            var unityActivity = AppPluginProvider.GetUnityActivity();

            gameService.Call("SetUnityContext", unityActivity);

            return gameService;
        }
#endif

#if UNITY_ANDROID
        private static AndroidJavaObject GetGameLoginServiceInstance()
        {
            var loginService = AppPluginProvider.GetLoginService();
            var unityActivity = AppPluginProvider.GetUnityActivity();

            loginService.Call("SetUnityContext", unityActivity);

            return loginService;
        }
#endif

#if UNITY_ANDROID
        public static void InitGameService(
             string clientId
            ,string clientSecret,
            DelegateCore.OnSuccessInit onSuccess,
            DelegateCore.OnError onError)
        {
   
            var gameService = GetGameServiceInstance();

            gameService.Call("InitGameService",
                clientId,
                clientSecret,
                new IGameServiceCallback(callBack => {
                        if(callBack.Equals("Success"))
                            onSuccess.Invoke(gameService);
                    },
                    onError.Invoke));
        }

#endif

#if UNITY_ANDROID

        public static void InitGameLoginService(
             bool checkAppStatus
            ,bool checkOptionalUpdate
            ,DelegateCore.OnSuccessInit onSuccess,
            DelegateCore.OnError onError)
        {

            var loginService = GetGameLoginServiceInstance();

            loginService.Call("InitLoginService",
                checkAppStatus,
                checkOptionalUpdate,
                new IGameServiceCallback(callBack => {
                        if (callBack.Equals("Success"))
                            onSuccess.Invoke(loginService);
                    },
                    onError.Invoke));
        }

#endif



    }
}
