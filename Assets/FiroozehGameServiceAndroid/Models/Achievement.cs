// <copyright file="Achievement.cs" company="Firoozeh Technology LTD">
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
    [Serializable]
    public class Achievement
    {

        [JsonProperty("name")]
        public string Name { set; get; }
        
        [JsonProperty("key")]
        public string Key { set; get; }
        
        [JsonProperty("desc")]
        public string Desc { set; get; }
        
        [JsonProperty("point")]
        public int Point { set; get; }
        
        [JsonProperty("image")]
        public string Image { set; get; }
        
        [JsonProperty("status")]
        public bool Status { set; get; }
        
        [JsonProperty("game")]
        public string Game { set; get; }
        
        [JsonProperty("earned")]
        public bool Earned { set; get; }
        
        
        public override string ToString()
        {
            return "Achievement{" +
                   "name='" + Name + '\'' +
                   ", key='" + Key + '\'' +
                   ", desc='" + Desc + '\'' +
                   ", point=" + Point +
                   ", image='" + Image + '\'' +
                   ", status=" + Status +
                   ", game='" + Game + '\'' +
                   ", earned=" + Earned +
                   '}';
        }
    }
}

