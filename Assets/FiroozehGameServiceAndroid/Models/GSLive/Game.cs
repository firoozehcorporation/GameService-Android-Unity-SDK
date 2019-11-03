// <copyright file="Game.cs" company="Firoozeh Technology LTD">
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
    /// Represents Game Data Model In GameService MultiPlayer System (GSLive)
    /// </summary>
    [Serializable]
    public class Game
    {
        /// <summary>
        /// Gets the Game id.
        /// </summary>
        /// <value>the Game id</value>
        [JsonProperty("_id")] 
        public string Id { get; set; }

        
        /// <summary>
        /// Gets the Game Logo URL.
        /// </summary>
        /// <value>the Game Logo</value>
        [JsonProperty("logo")]
        public string Logo{ get; set; }
        
        
        /// <summary>
        /// Gets the Game Name.
        /// </summary>
        /// <value>the Game Name</value>
        [JsonProperty("name")]
        public string Name{ get; set; }
    }
}