using FiroozehGameServiceAndroid.Core;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Interfaces.GSLive.Chat
{
    /// <summary>
    /// Represents GameService Chat Internal interface
    /// </summary>
    public class IChatListener : AndroidJavaProxy
    {
        private readonly DelegateCore.OnEvent _event;
        private readonly DelegateCore.OnError _error;
        
        public IChatListener(DelegateCore.OnEvent Event,DelegateCore.OnError error) 
            : base("ir.firoozehcorp.gameservice.android.unity.Command.Interfaces.ChatListener")
        {
            _event = Event;
            _error = error;    
        }

        void OnEvent(int type , string payload)
        {
            _event.Invoke(type,payload);
        }

        void OnError(string error)
        {
            _error.Invoke(error);
        }
    }
}