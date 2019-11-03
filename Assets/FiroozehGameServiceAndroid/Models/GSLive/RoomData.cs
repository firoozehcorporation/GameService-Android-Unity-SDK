// <copyright file="RoomData.cs" company="Firoozeh Technology LTD">
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
    /// Represents RoomData Data Model In GameService MultiPlayer System (GSLive)
    /// </summary>
    [Serializable]
    public class RoomData
    {
        /// <summary>
        /// Gets the Current Room id.
        /// </summary>
        /// <value>the Room id</value>
        [JsonProperty("1")]
        public string Id { set; get; }
        
        
        /// <summary>
        /// Gets the Room Name.
        /// it Set in GSLiveOption <see cref="FiroozehGameServiceAndroid.Core.GSLive.GSLiveOption"/>
        /// </summary>
        /// <value>the Room Name</value>
        [JsonProperty("2")]
        public string Name { set; get; }
                
        
        /// <summary>
        /// Gets the Room Logo URL.
        /// </summary>
        /// <value>the Room Logo URL</value>
        [JsonProperty("3")]
        public string Logo { set; get; }
                
        
        /// <summary>
        /// Gets the Room Creator Id.
        /// </summary>
        /// <value>the Room Creator Id</value>
        [JsonProperty("4")]
        public string Creator { set; get; }
        
        
        /// <summary>
        /// Gets the Room Minimum Member Value To Accept.
        /// it Set in GSLiveOption <see cref="FiroozehGameServiceAndroid.Core.GSLive.GSLiveOption"/>
        /// </summary>
        /// <value>the Room Minimum Member Value To Accept</value>
        [JsonProperty("5")]
        public int Min { set; get; }
        
        
        /// <summary>
        /// Gets the Room Minimum Member Value To Accept.
        /// it Set in GSLiveOption <see cref="FiroozehGameServiceAndroid.Core.GSLive.GSLiveOption"/>
        /// </summary>
        /// <value>the Room Maximum Member Value To Accept</value>
        [JsonProperty("6")]
        public int Max { set; get; }        
              
        
        /// <summary>
        /// Gets the Room Role Value.
        /// it Set in GSLiveOption <see cref="FiroozehGameServiceAndroid.Core.GSLive.GSLiveOption"/>
        /// </summary>
        /// <value>the Room Role Value</value>
        [JsonProperty("7")]
        public string Role { set; get; }
        
        
        /// <summary>
        /// Gets the Room Privacy Value.
        /// it Set in GSLiveOption <see cref="FiroozehGameServiceAndroid.Core.GSLive.GSLiveOption"/>
        /// </summary>
        /// <value>the Room Privacy Value</value>
        [JsonProperty("8")]
        public bool IsPrivate { set; get; }
                
        
        /// <summary>
        /// Gets the Room Status Value.
        /// </summary>
        /// <value>the Room Status Value</value>
        [JsonProperty("9")]
        public int Status { set; get; }
        
        
        /// <summary>
        /// Gets the Room Players Joined Count 
        /// </summary>
        /// <value>the Room Players Joined Count </value>
        [JsonProperty("10")]
        public int JoinedPlayers { set; get; }

       
    }
}