// <copyright file="GSLiveRealTimeListener.cs" company="Firoozeh Technology LTD">
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

using System.Collections.Generic;
using FiroozehGameServiceAndroid.Enums.GSLive;
using FiroozehGameServiceAndroid.Enums.GSLive.RT;
using FiroozehGameServiceAndroid.Interfaces.GSLive.Command;
using FiroozehGameServiceAndroid.Models;
using FiroozehGameServiceAndroid.Models.GSLive;
using FiroozehGameServiceAndroid.Models.GSLive.RT;

/**
* @author Alireza Ghodrati
*/



namespace FiroozehGameServiceAndroid.Interfaces.GSLive.RT
{
    public interface GSLiveRealTimeListener : GSLiveCommandListeners
    {
        // Major Listeners
        /// <summary>
        /// If a player becomes a member of the game room, the result is returned
        /// </summary>
        /// <param name="joinData">New JoinData information</param>
        /// <param name="type">The type of new player added can be Normal or AutoMatch.</param>
        void OnJoin (JoinData joinData , JoinType type);
        
        
        /// <summary>
        /// If one player sends information into the game room, the result returns
        /// </summary>
        /// <param name="message">Information about the message Receive</param>
        /// <param name="type">Whether Private or Public is the type of message that can be sent</param>
        void OnMessageReceive (Message message , MessageType type);
        
        /// <summary>
        /// If one of the players leaves the game room, the result returns
        /// </summary>
        /// <param name="leave">Information on the player who has left the game room</param>
        void OnLeave (Leave leave);
        
        
        /// <summary>
        /// If you request players information in the game room, the result will be returned
        /// </summary>
        /// <param name="members">List of room players</param>
        void OnRoomMembersDetail(List<Member> members);

       // Another Listeners
        /// <summary>
        /// This function sounds like if the process of building the game room is done correctly
        /// </summary>
        void OnSuccess ();
        
        /// <summary>
        /// If this error occurs, this function called
        /// </summary>
        /// <param name="error">error</param>
        void OnRealTimeError(string error);
    }
}