// <copyright file="GSLiveChatListener.cs" company="Firoozeh Technology LTD">
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


namespace FiroozehGameServiceAndroid.Interfaces.GSLive.Chat
{
    /// <summary>
    /// Represents GSLive Chat Event Listener
    /// </summary>
    public interface GSLiveChatListener
    {
        
        /// <summary>
        /// If one of the players is chatting with you, the result is returned 
        /// </summary>
        /// <param name="chat">Chat information</param>
        void OnChatReceive(Models.GSLive.Chat.Chat chat);
        
        
        /// <summary>
        /// If a channel is created or subscribed by you, the result will return to this function
        /// </summary>
        /// <param name="channelName">Channel name</param>
        void OnSubscribeChannel(string channelName);
        
        
        /// <summary>
        /// If you leave a particular channel, the name returns the result in this function
        /// </summary>
        /// <param name="channelName">Channel name</param>
        void OnUnSubscribeChannel(string channelName);
        
        
        /// <summary>
        /// If an error occurs, the result is returned in this function
        /// </summary>
        /// <param name="error">Error received</param>
        void OnChatError(string error);
    }
}