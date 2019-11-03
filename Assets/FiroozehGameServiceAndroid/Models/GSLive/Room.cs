// <copyright file="Room.cs" company="Firoozeh Technology LTD">
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
    /// Represents Room Data Model In GameService MultiPlayer System (GSLive)
    /// </summary>
    [Serializable]
    public class Room
    {
        
        /// <summary>
        /// Gets the Room id.
        /// You Can Use it In MultiPlayer Functions that Needs Room id
        /// </summary>
        /// <value>the Room id</value>
        [JsonProperty("_id")]
        public string Id { set; get; }
        
        
        /// <summary>
        /// Gets the Room Name.
        /// it Set in GSLiveOption <see cref="FiroozehGameServiceAndroid.Core.GSLive.GSLiveOption"/>
        /// </summary>
        /// <value>the Room Name</value>
        [JsonProperty("name")]
        public string Name { set; get; }
                
        
        /// <summary>
        /// Gets the Room Logo URL.
        /// </summary>
        /// <value>the Room Logo URL</value>
        [JsonProperty("logo")]
        public string Logo { set; get; }
                
        
        /// <summary>
        /// Gets the Room Creator Id.
        /// </summary>
        /// <value>the Room Creator Id</value>
        [JsonProperty("creator")]
        public string Creator { set; get; }
        
        /// <summary>
        /// Gets the Room Players Member Id.
        /// </summary>
        /// <value>the Room Players Member Id</value>
        [JsonProperty("members")]
        public string[] PlayersId { set; get; }
        
        
        /// <summary>
        /// Gets the Room Minimum Member Value To Accept.
        /// it Set in GSLiveOption <see cref="FiroozehGameServiceAndroid.Core.GSLive.GSLiveOption"/>
        /// </summary>
        /// <value>the Room Minimum Member Value To Accept</value>
        [JsonProperty("min")]
        public int Min { set; get; }
        
        
        /// <summary>
        /// Gets the Room Minimum Member Value To Accept.
        /// it Set in GSLiveOption <see cref="FiroozehGameServiceAndroid.Core.GSLive.GSLiveOption"/>
        /// </summary>
        /// <value>the Room Maximum Member Value To Accept</value>
        [JsonProperty("max")]
        public int Max { set; get; }        
                
        
        /// <summary>
        /// Gets the Room Role Value.
        /// it Set in GSLiveOption <see cref="FiroozehGameServiceAndroid.Core.GSLive.GSLiveOption"/>
        /// </summary>
        /// <value>the Room Role Value</value>
        [JsonProperty("role")]
        public string Role { set; get; }
        
        
        /// <summary>
        /// Gets the Game Id
        /// </summary>
        /// <value>the the Game Id</value>
        [JsonProperty("game")]
        public string GameId { set; get; }
        
        
        /// <summary>
        /// Gets the Room Privacy Value.
        /// it Set in GSLiveOption <see cref="FiroozehGameServiceAndroid.Core.GSLive.GSLiveOption"/>
        /// </summary>
        /// <value>the Room Privacy Value</value>
        [JsonProperty("private")]
        public bool IsPrivate { set; get; }
                
        
        /// <summary>
        /// Gets the Room Status Value.
        /// </summary>
        /// <value>the Room Status Value</value>
        [JsonProperty("status")]
        public int Status { set; get; }
        
    }
}