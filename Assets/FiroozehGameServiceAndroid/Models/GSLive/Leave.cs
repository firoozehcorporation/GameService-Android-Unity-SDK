// <copyright file="Leave.cs" company="Firoozeh Technology LTD">
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


namespace FiroozehGameServiceAndroid.Models.GSLive
{
    /// <summary>
    /// Represents Leave Data Model In GameService MultiPlayer System (GSLive)
    /// </summary>
    [Serializable]
    public class Leave
    {
        /// <summary>
        /// Gets the Room id
        /// </summary>
        /// <value>the Room id</value>
        [JsonProperty("1")]
        public string RoomId { set; get; }
        
        
        /// <summary>
        /// Gets the Player Member Data Who Left the Room
        /// </summary>
        /// <value>the Player Member Data Who Left the Room</value>
        [JsonProperty("2")]
        public Member MemberLeave { set; get; }
       
    }
}