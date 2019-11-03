// <copyright file="Message.cs" company="Firoozeh Technology LTD">
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

using Newtonsoft.Json;

namespace FiroozehGameServiceAndroid.Models.GSLive.Chat
{
    /// <summary>
    /// Represents Chat Data Model In GameService Command System
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// Gets the Chat Privacy.
        /// </summary>
        /// <value>the Chat Privacy</value>
        [JsonProperty("0")]                  
        public bool IsPrivate { set; get; }   
        
        /// <summary>
        /// Gets the Chat Receiver Id.
        /// </summary>
        /// <value>the Chat Receiver Id</value>
        [JsonProperty("1")]
        public string ReceiverId { set; get; }
        
        /// <summary>
        /// Gets the Chat Sender User.
        /// </summary>
        /// <value>the Chat Sender User</value>
        [JsonProperty("2")]                      
        public User Sender { set; get; }
        
        /// <summary>
        /// Gets the Chat Message Data
        /// </summary>
        /// <value>the Chat Message Data</value>
        [JsonProperty("3")]                      
        public string Message { set; get; }
        
        
        /// <summary>
        /// Gets the Chat Message Send Time in Unix Time
        /// </summary>
        /// <value>the Chat Message Send Time in Unix Time</value>
        [JsonProperty("4")]                      
        public long SendTime { set; get; }
    }
}