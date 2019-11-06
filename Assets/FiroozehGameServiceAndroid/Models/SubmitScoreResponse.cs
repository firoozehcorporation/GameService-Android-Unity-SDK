// <copyright file="SubmitScoreResponse.cs" company="Firoozeh Technology LTD">
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
using System.Collections.Generic;
using Newtonsoft.Json;

/**
* @author Alireza Ghodrati
*/



namespace FiroozehGameServiceAndroid.Models
{
    /// <summary>
    /// Represents SubmitScoreResponse Data Model In Game Service Basic API
    /// </summary>
    [Serializable]
    public class SubmitScoreResponse
    {
        /// <summary>
        /// Gets the LeaderBoard.
        /// </summary>
        /// <value>the LeaderBoard</value>
        [JsonProperty("leaderboard_r")]
        public LeaderBoard Leaderboard { set; get; }

        
        /// <summary>
        /// Gets the Score Value.
        /// </summary>
        /// <value>the Score Value</value>
        [JsonProperty("score")]
        public int Score { set; get; }
        
        
        /// <summary>
        /// Gets the Tries Value.
        /// How Many Tries To Submit Score
        /// </summary>
        /// <value>the Tries Value</value>
        [JsonProperty("tries")]
        public int Tries { set; get; }
               
    }
}