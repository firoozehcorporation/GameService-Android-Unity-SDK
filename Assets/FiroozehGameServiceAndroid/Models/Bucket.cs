// <copyright file="Bucket.cs" company="Firoozeh Technology LTD">
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

namespace FiroozehGameServiceAndroid.Models
{
    /// <summary>
    /// Represents Bucket Data Model In Game Service Basic API
    /// </summary>
    [Serializable]
    public class Bucket<TBucket>
    {
        /// <summary>
        /// Gets the Bucket ID.
        /// </summary>
        /// <value>the Bucket ID</value>
        [JsonProperty("bucket")]
        public string BucketId { set; get; }
        
        /// <summary>
        /// Gets the Bucket Object ID.
        /// </summary>
        /// <value>the Bucket Object ID</value>
        [JsonProperty("_id")]
        public string Id { set; get; }

        [JsonProperty("data")]
        private string _rawBucket;

        
        /// <summary>
        /// Gets the Bucket Object.
        /// </summary>
        /// <value>the Bucket Object</value>
        public TBucket BucketData
        {
            get { return JsonConvert.DeserializeObject<TBucket>(_rawBucket); }
        }
    }
}