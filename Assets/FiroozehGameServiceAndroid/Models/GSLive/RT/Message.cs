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


using System;
using Newtonsoft.Json;

/**
* @author Alireza Ghodrati
*/


namespace FiroozehGameServiceAndroid.Models.GSLive.RT
{
    /// <summary>
    /// Represents Message Data Model In GameService RealTime MultiPlayer System
    /// </summary>
    [Serializable]
    public class Message
    {
        
        /// <summary>
        /// Gets the RoomId Receive This Message.
        /// </summary>
        /// <value>the RoomId Receive This Message</value>
        [JsonProperty("1")]
        public string RoomId { set; get; }
         
        
        /// <summary>
        /// Gets the Sender Id.
        /// </summary>
        /// <value>the Sender Id</value>
        [JsonProperty("2")]
        public string SenderId { set; get; }
        
        
        /// <summary>
        /// Gets the Receiver Id.
        /// </summary>
        /// <value>the Receiver Id</value>
        [JsonProperty("3")]
        public string ReceiverId { set; get; }
        
        
        /// <summary>
        /// Gets the Message Data
        /// </summary>
        /// <value>the Message Data</value>
        [JsonProperty("4")]
        public string Data { set; get; }
    }
}