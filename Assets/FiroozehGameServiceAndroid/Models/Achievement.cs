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
/**
* @author Alireza Ghodrati
*/
namespace FiroozehGameServiceAndroid.Models
{
    [Serializable]
    public class Achievement
    {

        public string name { set; get; }
        public string key { set; get; }
        public string desc { set; get; }
        public int point { set; get; }
        public string image { set; get; }
        public bool status { set; get; }
        public string game { set; get; }
        public bool earned { set; get; }
        public override string ToString()
        {
            return "Achievement{" +
                   "name='" + name + '\'' +
                   ", key='" + key + '\'' +
                   ", desc='" + desc + '\'' +
                   ", point=" + point +
                   ", image='" + image + '\'' +
                   ", status=" + status +
                   ", game='" + game + '\'' +
                   ", earned=" + earned +
                   '}';
        }
    }
}

