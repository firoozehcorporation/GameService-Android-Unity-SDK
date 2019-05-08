using System;
using FiroozehGameServiceAndroid.Core;

namespace FiroozehGameServiceAndroid.Builders.App
{
    internal static class GameServiceAppInitializer
    {
        internal static void Init(
            GameServiceClientConfiguration configuration
            ,Action<GameService> onSuccess
            ,Action<string> onError)
        {

                FiroozehGameServiceLoginCheck.CheckUserLoginStatus(
                    configuration.CheckAppStatus
                    , configuration.CheckOptionalUpdate
                    , isLogin =>
                    {
                        if (isLogin)
                            GameServiceInitializer.Init(configuration.ClientId, configuration.ClientSecret, s =>
                                {
                                    onSuccess.Invoke(new GameService(s,configuration.HaveNotification));
                                }
                                , onError.Invoke);
                        else
                            FiroozehGameServiceLoginCheck.ShowLoginUI(
                                configuration.CheckAppStatus
                                , configuration.CheckOptionalUpdate
                                , r =>
                                {
                                    if (r)
                                        GameServiceInitializer.Init(configuration.ClientId, configuration.ClientSecret, s =>
                                            {
                                                onSuccess.Invoke(new GameService(s,configuration.HaveNotification));
                                            }
                                            , onError.Invoke);
                                }, onError.Invoke);
                    }, onError.Invoke);
            
        }
    }
}