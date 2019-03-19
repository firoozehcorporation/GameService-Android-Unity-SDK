using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Interfaces;

namespace FiroozehGameServiceAndroid.Builders
{
    public static class FiroozehGameServiceLoginCheck
    {
#if UNITY_ANDROID
        public static void CheckUserLoginStatus(
             bool checkAppStatus
            ,bool checkOptionalUpdate
            ,DelegateCore.IsUserLogin userLogin
            , DelegateCore.OnError error)
        {

     
            GameServicePluginHandler.InitGameLoginService(
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

            GameServicePluginHandler.InitGameLoginService(checkAppStatus,checkOptionalUpdate
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
