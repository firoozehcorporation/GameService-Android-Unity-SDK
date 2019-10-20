// <copyright file="GSLiveChat.cs" company="Firoozeh Technology LTD">
// Copyright (C) 2019 Firoozeh Technology LTD. All Rights Reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>


/**
* @author Alireza Ghodrati
*/

using FiroozehGameServiceAndroid.Interfaces.GSLive.Chat;
using FiroozehGameServiceAndroid.Models.GSLive.Chat;
using FiroozehGameServiceAndroid.Utils;
using Newtonsoft.Json;

namespace FiroozehGameServiceAndroid.Core.GSLive
{
    public class GSLiveChat
    {
        private const string Tag = "GSLiveChat";
        private GSLiveChatListener _chatListener;
        public bool IsAvailable { get; private set; }
        
        private const int ActionSubscribe = 12;
        private const int ActionChat = 13;
        private const int ActionUnSubscribe = 14;

        public void SetListener(GSLiveChatListener listener)
        {
            if (listener == null)
            {
                LogUtil.LogError(Tag,"Listener Must not be NULL");
                return;
            }
            
            var eventListener = new IChatListener((type, payload) =>
            {
                switch (type)
                {
                    case ActionChat:
                        _chatListener.OnChatReceive(JsonConvert.DeserializeObject<Chat>(payload));
                        break;
                    case ActionSubscribe:
                         _chatListener.OnSubscribeChannel(payload);
                        break;
                    case ActionUnSubscribe:
                        _chatListener.OnUnSubscribeChannel(payload);
                        break;
                }
            },listener.OnChatError);
            
            IsAvailable = true;
            _chatListener = listener;
            SetEventListener(eventListener);
        }


        private static void SetEventListener(IChatListener listener)
        {
            var chat = GSLiveProvider.GetGSLiveChat();
            chat.Call("setListener", listener);
        }
        
        
        public void SubscribeChannel(string channelName)
        {
            if (_chatListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var chat = GSLiveProvider.GetGSLiveChat();    
            chat.Call("SubscribeChannel",channelName);     
        }
        
        public void UnSubscribeChannel(string channelName)
        {
            if (_chatListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var chat = GSLiveProvider.GetGSLiveChat();    
            chat.Call("UnSubscribeChannel",channelName);     
        }
        
        
        public void SendChannelMessage(string channelName,string message)
        {
            if (_chatListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var chat = GSLiveProvider.GetGSLiveChat();    
            chat.Call("SendChannelMessage",channelName,message);     
        }
    }
}