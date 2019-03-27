using FiroozehGameServiceAndroid.Core;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Interfaces
{
    public class IGameServiceLoginCheck : AndroidJavaProxy
    {

        private readonly DelegateCore.IsUserLogin _UserLogin;
        private readonly DelegateCore.OnError _OnError;

        public IGameServiceLoginCheck(DelegateCore.IsUserLogin isUserLoggedIn, DelegateCore.OnError onError)
            : base("ir.FiroozehCorp.UnityPlugin.Interfaces.IGameServiceLoginCheck")
        {
            _UserLogin = isUserLoggedIn;
            _OnError = onError;
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
