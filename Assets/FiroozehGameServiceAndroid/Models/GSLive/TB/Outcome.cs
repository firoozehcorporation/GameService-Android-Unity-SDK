// <copyright file="Outcome.cs" company="Firoozeh Technology LTD">
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

using Newtonsoft.Json;

/**
* @author Alireza Ghodrati
*/


namespace FiroozehGameServiceAndroid.Models.GSLive.TB
{
    /// <summary>
    /// Represents Outcome Data Model In GameService TurnBased MultiPlayer System
    /// </summary>
    public class Outcome
    {
        
        /// <summary>
        /// Gets the Placement of Outcome.
        /// </summary>
        /// <value>the Placement of Outcome</value>
        [JsonProperty("0")]
        public int Placement { get; set; }
        
        
        /// <summary>
        /// Gets the Result of Outcome.
        /// </summary>
        /// <value>the Result of Outcome</value>
        [JsonProperty("1")]
        public string Result { get; set; }
        
    }
}