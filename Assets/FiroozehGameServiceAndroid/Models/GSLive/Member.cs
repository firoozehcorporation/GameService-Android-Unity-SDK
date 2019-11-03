// <copyright file="Member.cs" company="Firoozeh Technology LTD">
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

namespace FiroozehGameServiceAndroid.Models.GSLive
{
    /// <summary>
    /// Represents Member Data Model In GameService MultiPlayer System (GSLive)
    /// </summary>
    [Serializable]
    public class Member
    {
        /// <summary>
        /// Gets the Member ID
        /// You Can Use it In MultiPlayer Functions that Needs Member id
        /// </summary>
        /// <value>the Member ID</value>
        [JsonProperty("_id")]
        public string Id { set; get; }
         
        
        /// <summary>
        /// Gets the Member User Data
        /// </summary>
        /// <value>the Member User Data</value>
        [JsonProperty("user")]
        public User User { set; get; }
    }
}