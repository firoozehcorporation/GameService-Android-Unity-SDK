// <copyright file="RoomData.cs" company="Firoozeh Technology LTD">
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

namespace FiroozehGameServiceAndroid.Models.GSLive
{
    public class RoomData
    {
        [JsonProperty("1")]
        public string Id { set; get; }
        
        [JsonProperty("2")]
        public string Name { set; get; }
                
        [JsonProperty("3")]
        public string Logo { set; get; }
                
        [JsonProperty("4")]
        public string Creator { set; get; }
        
        [JsonProperty("5")]
        public int Min { set; get; }
        
        [JsonProperty("6")]
        public int Max { set; get; }        
                
        [JsonProperty("7")]
        public string Role { set; get; }
        
        [JsonProperty("8")]
        public bool IsPrivate { set; get; }
                
        [JsonProperty("9")]
        public int Status { set; get; }
        
        [JsonProperty("10")]
        public int JoinedMember { set; get; }

       
    }
}