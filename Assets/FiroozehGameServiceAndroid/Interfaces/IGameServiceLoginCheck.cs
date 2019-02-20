using FiroozehGameServiceAndroid.Core;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Interfaces
{
    public class GameServiceLoginCheck : AndroidJavaProxy
    {

        private DelegateCore.IsUserLogin _UserLogin;
        private DelegateCore.OnError _OnError;

        public GameServiceLoginCheck(DelegateCore.IsUserLogin isUserLoggedIn, DelegateCore.OnError onError)
            : base("ir.firoozeh.unitymodule.Interfaces.IGameServiceLoginCheck")
        {
            this._UserLogin = isUserLoggedIn;
            this._OnError = onError;
        }

        public void IsLoggedIn(bool status)
        {
            _UserLogin.Invoke(status);
        }

        public void OnError(string error)
        {
            _OnError.Invoke(error);
        }
    }
}
