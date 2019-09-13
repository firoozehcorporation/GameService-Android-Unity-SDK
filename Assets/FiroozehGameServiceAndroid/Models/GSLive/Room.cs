// <copyright file="Room.cs" company="Firoozeh Technology LTD">
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
    public class Room
    {
        
        [JsonProperty("_id")]
        public string Id { set; get; }
        
        [JsonProperty("name")]
        public string Name { set; get; }
                
        [JsonProperty("logo")]
        public string Logo { set; get; }
                
        [JsonProperty("creator")]
        public string Creator { set; get; }
        
        [JsonProperty("members")]
        public string[] MembersId { set; get; }
        
        [JsonProperty("min")]
        public int Min { set; get; }
        
        [JsonProperty("max")]
        public int Max { set; get; }        
                
        [JsonProperty("role")]
        public string Role { set; get; }
        
        [JsonProperty("game")]
        public string GameId { set; get; }
        
        [JsonProperty("private")]
        public bool IsPrivate { set; get; }
                
        [JsonProperty("status")]
        public int Status { set; get; }
        
    }
}