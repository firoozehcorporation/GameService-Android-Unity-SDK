// <copyright file="GSLiveTurnBasedListener.cs" company="Firoozeh Technology LTD">
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
using FiroozehGameServiceAndroid.Models;
using FiroozehGameServiceAndroid.Models.GSLive.RT;
using FiroozehGameServiceAndroid.Models.GSLive.TB;
using Leave = FiroozehGameServiceAndroid.Models.GSLive.TB.Leave;
using Member = FiroozehGameServiceAndroid.Models.GSLive.TB.Member;

/**
* @author Alireza Ghodrati
*/

namespace FiroozehGameServiceAndroid.Interfaces.GSLive.TB
{
    public interface GSLiveTurnBasedListener
    {

        // Major Listeners
        void OnTakeTurn(Turn turn);
        void OnRoomMembersDetail(List<Member> members);
        void OnLeave(Leave leave);
        void OnFinish(Finish finish);
        void OnComplete(Outcome outcome);
        
        // Invite Listeners
        void OnInviteList (List<Invite> invites);
        void OnInviteSend();
        void OnFindUsers(List<User> users);
        
        
        // Another Listeners
        void OnSuccess ();
        void OnTurnBasedError(string error);
    }
}