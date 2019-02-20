using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Interfaces;

namespace FiroozehGameServiceAndroid.Builders
{
    public sealed class FiroozehGameServiceLoginCheck
    {
#if UNITY_ANDROID
        public static void CheckUserLoginStatus(DelegateCore.IsUserLogin userLogin, DelegateCore.OnError error)
        {

     
            GameServicePluginHandler.InitGameLoginService(s =>
                {
                    s.Call("IsUserLoggedIn", new GameServiceLoginCheck(
                        userLogin.Invoke, error.Invoke));
                } , error.Invoke);
        
        }
#endif
#if UNITY_ANDROID
        public static void ShowLoginUI(DelegateCore.IsUserLogin isUserLogin,DelegateCore.OnError error)
        {

            GameServicePluginHandler.InitGameLoginService(s =>
                {
                    s.Call("ShowLoginUI", new GameServiceLoginCheck(
                        isUserLogin.Invoke, error.Invoke));
                }
                , error.Invoke);

     
        }
#endif

    }
}
