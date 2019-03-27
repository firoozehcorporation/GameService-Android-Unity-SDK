using FiroozehGameServiceAndroid.Core;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Interfaces
{
    public class IGameServiceCallback : AndroidJavaProxy
    {

        private readonly DelegateCore.OnCallback _oncallback;
        private readonly DelegateCore.OnError _onError;

        public IGameServiceCallback(DelegateCore.OnCallback callback, DelegateCore.OnError onError)
            : base("ir.FiroozehCorp.UnityPlugin.Interfaces.IGameServiceCallback")
        {
            _oncallback = callback;
            _onError = onError;

        }

        void OnCallback(string Result)
        {
            _oncallback.Invoke(Result);
        }

        void OnError(string Error)
        {
            _onError.Invoke(Error);
        }



    }
}
