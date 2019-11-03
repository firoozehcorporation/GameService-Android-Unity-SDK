// <copyright file="LeaderBoard.cs" company="Firoozeh Technology LTD">
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
    /// Represents LeaderBoard Data Model In Game Service Basic API
    /// </summary>
    [Serializable]
    public class LeaderBoard
    {
        /// <summary>
        /// Gets the LeaderBoard Name.
        /// </summary>
        /// <value>the LeaderBoard Name</value>
        [JsonProperty("name")]
        public string Name { set; get; }

        
        /// <summary>
        /// Gets the LeaderBoard Key.
        /// You Can Use It To Submit Score in a LeaderBoard
        /// </summary>
        /// <value>the LeaderBoard Key</value>
        [JsonProperty("key")]
        public string Key { set; get; }

        
        /// <summary>
        /// Gets the LeaderBoard status.
        /// if the status is True You Can Submit Score in LeaderBoard
        /// </summary>
        /// <value>the LeaderBoard status</value>
        [JsonProperty("status")]
        public bool Status { set; get; }

        
        /// <summary>
        /// Gets the LeaderBoard Cover URL.
        /// </summary>
        /// <value>the LeaderBoard Cover URL</value>
        [JsonProperty("image")]
        public string Image { set; get; }

        
        /// <summary>
        /// Gets the LeaderBoard Form Value.
        /// this Value Sets In GameService Developers Panel.
        /// </summary>
        /// <value>the LeaderBoard From Value</value>
        [JsonProperty("from")]
        public int From { set; get; }

        
        /// <summary>
        /// Gets the LeaderBoard To Value.
        /// this Value Sets In GameService Developers Panel.
        /// </summary>
        /// <value>the LeaderBoard To Value</value>
        [JsonProperty("to")]
        public int To { set; get; }

        
        /// <summary>
        /// Gets the LeaderBoard Order Type.
        /// this Type Sets In GameService Developers Panel.
        /// </summary>
        /// <value>the LeaderBoard Order Type</value>
        [JsonProperty("order")]
        public int Order { set; get; }

        
        /// <summary>
        /// Gets the Game id.
        /// </summary>
        /// <value>the Game id</value>
        [JsonProperty("game")]
        public string Game { set; get; }


        public override string ToString()
        {
            return "LeaderBoard{" +
                   "name='" + Name + '\'' +
                   ", key='" + Key + '\'' +
                   ", status=" + Status +
                   ", image='" + Image + '\'' +
                   ", from=" + From +
                   ", to=" + To +
                   ", order=" + Order +
                   ", game='" + Game + '\'' +
                   '}';
        }
    }
}
