// <copyright file="LeaderBoardDetails.cs" company="Firoozeh Technology LTD">
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
    /// Represents LeaderBoardDetails Data Model In Game Service Basic API
    /// </summary>
    [Serializable]
    public class LeaderBoardDetails
    {

        /// <summary>
        /// Gets the LeaderBoard.
        /// </summary>
        /// <value>the LeaderBoard</value>
        [JsonProperty("leaderboard")]
        public LeaderBoard Leaderboard { set; get; }

        
        /// <summary>
        /// Gets the List Of Scores.
        /// </summary>
        /// <value>the List Of Scores</value>
        [JsonProperty("scores")]
        public List<Score> Scores { set; get; }

        public override string ToString()
        {
            return "LeaderBoardReceiver{" +
                   "leaderboard=" + Leaderboard +
                   ", scores=" + Scores +
                   '}';
        }
     
    }
}

