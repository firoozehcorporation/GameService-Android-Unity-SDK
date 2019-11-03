// <copyright file="GSLiveOption.cs" company="Firoozeh Technology LTD">
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

namespace FiroozehGameServiceAndroid.Core.GSLive
{
    /// <summary>
    /// Represents GSLive GSLiveOption
    /// </summary>
    public class GSLiveOption
    {
        /// <summary>
        /// Represents GSLive CreateRoomOption
        /// </summary>
        public class CreateRoomOption
        {
            public string RoomName { set; get; }   
            public int MinPlayer { set; get; }
            public int MaxPlayer { set; get; }
            public string Role { set; get; }
            public bool IsPrivate { set; get; }
        }
        
        /// <summary>
        /// Represents GSLive AutoMatchOption
        /// </summary>
        public class AutoMatchOption
        {
            public int MinPlayer { set; get; }
            public int MaxPlayer { set; get; }
            public string Role { set; get; }
        }

    }
}