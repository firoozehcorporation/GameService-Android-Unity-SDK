// <copyright file="JoinData.cs" company="Firoozeh Technology LTD">
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

namespace FiroozehGameServiceAndroid.Models.GSLive
{
    /// <summary>
    /// Represents JoinData Data Model In GameService MultiPlayer System (GSLive)
    /// </summary>
    [Serializable]
    public class JoinData
    {
        /// <summary>
        /// Gets the Room Join Type.
        /// </summary>
        /// <value>the Room Join Type</value>
        /// <see cref="FiroozehGameServiceAndroid.Enums.GSLive.JoinType"/>
        [JsonProperty("1")]
        public int JoinType { get; set; }
        
        
        /// <summary>
        /// Gets the Room Join Data.
        /// </summary>
        /// <value>the Room Join Data</value>
        [JsonProperty("2")]
        public RoomData RoomData { get; set; }
        
        
        /// <summary>
        /// Gets the Player Member Who Joined To Room.
        /// </summary>
        /// <value>the Player Member Who Joined To Room</value>
        [JsonProperty("3")]
        public Member JoinedMember { get; set; }
    }
}