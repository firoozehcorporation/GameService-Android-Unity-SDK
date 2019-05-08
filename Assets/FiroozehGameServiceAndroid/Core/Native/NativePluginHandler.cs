using FiroozehGameServiceAndroid.Interfaces;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Core.Native
{
    public static class NativePluginHandler
    {
   
        
#if UNITY_ANDROID
        public static AndroidJavaObject GetGameServiceInstance()
        {
            var gameService = NativePluginProvider.GetGameService();
            var unityActivity = NativePluginProvider.GetUnityActivity();

            gameService.Call("SetUnityContext", unityActivity);

            return gameService;
        }
#endif
        
#if UNITY_ANDROID
        public static void InitGameService(
            AndroidJavaObject gameService
            ,GameServiceClientConfiguration configuration
            ,DelegateCore.OnSuccessInit onSuccess,
            DelegateCore.OnError onError)
        {

            gameService.Call("InitGameService"
                ,configuration.ClientId
                ,configuration.ClientSecret
                ,new IGameServiceNativeCallback(c =>
                {
                    if(c.Equals("Success"))
                        onSuccess.Invoke(gameService);
                        
                }, onError.Invoke));

        }
#endif
        
    }
}
