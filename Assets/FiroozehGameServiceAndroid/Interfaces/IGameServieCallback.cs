using FiroozehGameServiceAndroid.Core;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Interfaces
{
    public class GameServiceCallback : AndroidJavaProxy
    {


   

        private DelegateCore.OnCallback _Oncallback;
        private DelegateCore.OnError _OnError;

        public GameServiceCallback(DelegateCore.OnCallback callback, DelegateCore.OnError onError)
            : base("ir.firoozeh.unitymodule.Interfaces.IGameServiceCallback")
        {
            this._Oncallback = callback;
            this._OnError = onError;

        }

        void OnCallback(string Result)
        {
            _Oncallback.Invoke(Result);
        }

        void OnError(string Error)
        {
            _OnError.Invoke(Error);
        }



    }
}
