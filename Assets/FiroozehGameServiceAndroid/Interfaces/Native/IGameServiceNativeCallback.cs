using FiroozehGameServiceAndroid.Core;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Interfaces
{
    public class IGameServiceNativeCallback : AndroidJavaProxy
    {
        private readonly DelegateCore.OnCallback _oncallback;
        private readonly DelegateCore.OnError _onError;

        public IGameServiceNativeCallback(DelegateCore.OnCallback callback, DelegateCore.OnError onError)
            : base("ir.FiroozehCorp.UnityPlugin.Native.Interfaces.IGameServiceCallback")
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