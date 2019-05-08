using System;
using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Core.Native;
using FiroozehGameServiceAndroid.Enums;

namespace FiroozehGameServiceAndroid.Builders.Native
{
    internal static class GameServiceNativeInitializer
    {
        internal static void Init(GameServiceClientConfiguration configuration
            ,Action<GameService> onSuccess
            ,Action<string> onError)
        {
            var nativeService =  NativePluginHandler.GetGameServiceInstance();
            NativePluginHandler.InitGameService(
                nativeService
                ,configuration
                ,gameService=>{ onSuccess.Invoke(new GameService(gameService,GameServiceType.Native,false));}
                ,onError.Invoke);
        }
    }
}