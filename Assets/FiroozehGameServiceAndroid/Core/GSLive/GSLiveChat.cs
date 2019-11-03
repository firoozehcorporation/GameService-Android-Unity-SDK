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
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace FiroozehGameServiceAndroid.Core.GSLive
{
    /// <summary>
    /// Represents Game Service Chat System
    /// </summary>
    public class GSLiveChat
    {
        private const string Tag = "GSLiveChat";
        private GSLiveChatListener _chatListener;
        public bool IsAvailable { get; private set; }
        
        private const int ActionSubscribe = 12;
        private const int ActionChat = 13;
        private const int ActionUnSubscribe = 14;

        /// <summary>
        /// Set Listener For Receive Chat System Events.
        /// </summary>
        /// <param name="listener">(Not NULL)Listener For Receive Chat System Events</param>
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
        
        
        /// <summary>
        /// Subscribe In Channel With channelName.
        /// </summary>
        /// <param name="channelName">(NOTNULL)Name of Channel You want To Subscribe</param>
        public void SubscribeChannel(string channelName)
        {
            if (_chatListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            
            if (channelName == null)
            {
                LogUtil.LogError(Tag, "channelName Must not be NULL");
                return;
            }

            var chat = GSLiveProvider.GetGSLiveChat();    
            chat.Call("SubscribeChannel",channelName);     
        }
        
        /// <summary>
        /// UnSubscribeChannel With channelName.
        /// </summary>
        /// <param name="channelName">(NOTNULL)Name of Channel You want To UnSubscribe</param>
        public void UnSubscribeChannel(string channelName)
        {
            if (_chatListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            
            if (channelName == null)
            {
                LogUtil.LogError(Tag, "channelName Must not be NULL");
                return;
            }

            var chat = GSLiveProvider.GetGSLiveChat();    
            chat.Call("UnSubscribeChannel",channelName);     
        }
        
        /// <summary>
        /// Send Message In SubscribedChannel.
        /// </summary>
        /// <param name="channelName">(NOTNULL)Name of Channel You want To Send Message</param>
        /// <param name="message">(NOTNULL)Message Data</param>

        public void SendChannelMessage(string channelName,string message)
        {
            if (_chatListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            
            if (channelName == null || message == null)
            {
                LogUtil.LogError(Tag, "Inputs Must not be NULL");
                return;
            }

            var chat = GSLiveProvider.GetGSLiveChat();    
            chat.Call("SendChannelMessage",channelName,message);     
        }
    }
}