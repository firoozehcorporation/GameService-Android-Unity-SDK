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

        void OnCallback(string result)
        {
            _Oncallback.Invoke(result);
        }

        void OnError(string error)
        {
            _OnError.Invoke(error);
        }



    }
}
