// <copyright file="Turn.cs" company="Firoozeh Technology LTD">
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

namespace FiroozehGameServiceAndroid.Models.GSLive.TB
{
    /// <summary>
    /// Represents Turn Data Model In GameService TurnBased MultiPlayer System
    /// </summary>
    [Serializable]
    public class Turn
    {
        
        /// <summary>
        /// Gets the Data Send In Turn By Other Player.
        /// </summary>
        /// <value>the Data Send In Turn By Other Player</value>
        [JsonProperty("0")]
        public string Data { get; set; }
        
        /// <summary>
        /// Gets The Player Member who has TakeTurn.
        /// </summary>
        /// <value>The Player Member who has TakeTurn</value>
        [JsonProperty("1")]
        public Member WhoTakeTurn { get; set; }
        
    }
}