using FiroozehGameServiceAndroid.Core;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Interfaces
{
    public class IGameServiceLoginCheck : AndroidJavaProxy
    {

        private DelegateCore.IsUserLogin _UserLogin;
        private DelegateCore.OnError _OnError;

        public IGameServiceLoginCheck(DelegateCore.IsUserLogin IsUserLoggedIn, DelegateCore.OnError OnError)
            : base("ir.firoozeh.unitymodule.Interfaces.IGameServiceLoginCheck")
        {
            this._UserLogin = IsUserLoggedIn;
            this._OnError = OnError;
        }

        public void isLoggedIn(bool Status)
        {
            _UserLogin.Invoke(Status);
        }

        public void OnError(string Error)
        {
            _OnError.Invoke(Error);
        }
    }
}
