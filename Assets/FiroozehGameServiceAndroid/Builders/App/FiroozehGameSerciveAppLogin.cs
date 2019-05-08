using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Core.App;
using FiroozehGameServiceAndroid.Interfaces;
using FiroozehGameServiceAndroid.Interfaces.App;

namespace FiroozehGameServiceAndroid.Builders.App
{
    public static class FiroozehGameServiceAppLoginCheck
    {
#if UNITY_ANDROID
        public static void CheckUserLoginStatus(
             bool checkAppStatus
            ,bool checkOptionalUpdate
            ,DelegateCore.IsUserLogin userLogin
            , DelegateCore.OnError error)
        {

     
            AppPluginHandler.InitGameLoginService(
                 checkAppStatus
                ,checkOptionalUpdate
                ,s=>
                {
                        s.Call("IsUserLoggedIn",
                            new IGameServiceLoginCheck(
                                userLogin.Invoke
                              , error.Invoke)); 
                } , error.Invoke);
        
        }
#endif
#if UNITY_ANDROID
        public static void ShowLoginUI(
            bool checkAppStatus
            ,bool checkOptionalUpdate  
            ,DelegateCore.IsUserLogin isUserLogin
            ,DelegateCore.OnError error)
        {

           AppPluginHandler.InitGameLoginService(checkAppStatus,checkOptionalUpdate
                ,s =>
                {
                    s.Call("ShowLoginUI",
                        new IGameServiceLoginCheck(
                        isUserLogin.Invoke, error.Invoke));
                }
                , error.Invoke);

     
        }
#endif

    }
}
