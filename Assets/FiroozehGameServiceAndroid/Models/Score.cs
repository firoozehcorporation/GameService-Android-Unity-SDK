// <copyright file="Score.cs" company="Firoozeh Technology LTD">
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


/**
* @author Alireza Ghodrati
*/


using System;
using Newtonsoft.Json;

namespace FiroozehGameServiceAndroid.Models
{
    /// <summary>
    /// Represents Score Data Model In Game Service Basic API
    /// </summary>
    [Serializable]
    public class Score
    {

        /// <summary>
        /// Gets the Game id.
        /// </summary>
        /// <value>the Game id</value>
        [JsonProperty("game")]
        public string Game { set; get; }

        
        /// <summary>
        /// Gets the User Submit this Score.
        /// </summary>
        /// <value>the User Submit this Score</value>
        [JsonProperty("user")]
        public User User { set; get; }

        /// <summary>
        /// Gets the Value of This Score.
        /// </summary>
        /// <value>the Value of This Score</value>
        [JsonProperty("value")]
        public int Value { set; get; }
    
        
        /// <summary>
        /// Gets the Rank of This Score.
        /// </summary>
        /// <value>the Rank of This Score</value>
        [JsonProperty("rank")]
        public int Rank { set; get; }
    
        /// <summary>
        /// Gets the Tries Count of This Score.
        /// </summary>
        /// <value>the Tries Count of This Score</value>
        [JsonProperty("tries")]
        public int Tries { set; get; }
    
        
        /// <summary>
        /// if this is Score Submit By You or Not
        /// </summary>
        /// <value>this Score Submit By You or Not</value>
        [JsonProperty("me")]
        public bool IsMe { set; get; }
    

        public override string ToString()
        {
            return "Score{" +
                   "game='" + Game + '\'' +
                   ", user='" + User + '\'' +
                   ", value=" + Value +
                   '}';
        }
    }
}

