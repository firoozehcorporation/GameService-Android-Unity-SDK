// <copyright file="GSLiveTB.cs" company="Firoozeh Technology LTD">
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


using System.Collections.Generic;
using FiroozehGameServiceAndroid.Enums.GSLive;
using FiroozehGameServiceAndroid.Enums.GSLive.RT;
using FiroozehGameServiceAndroid.Interfaces.GSLive.TB;
using FiroozehGameServiceAndroid.Models;
using FiroozehGameServiceAndroid.Models.GSLive;
using FiroozehGameServiceAndroid.Models.GSLive.RT;
using FiroozehGameServiceAndroid.Models.GSLive.TB;
using FiroozehGameServiceAndroid.Utils;
using Newtonsoft.Json;
using EventType = FiroozehGameServiceAndroid.Enums.GSLive.TB.EventType;
using Member = FiroozehGameServiceAndroid.Models.GSLive.Member;

namespace FiroozehGameServiceAndroid.Core.GSLive
{
#if UNITY_ANDROID
    /// <summary>
    /// Represents Game Service TurnBased MultiPlayer System
    /// </summary>
    public class GSLiveTB
    {
        private const string Tag = "GSLive-TurnBased";
        private GSLiveTurnBasedListener _turnBasedListener;
        public bool IsAvailable { get; private set; }

        
          private static void SetEventListener(IEventListener listener)
        {
           var tb = GSLiveProvider.GetGSLiveTB();
            tb.Call("SetListener", listener);
        }

        /// <summary>
        /// Set Listener For Receive GSLive TurnBased System Events.
        /// </summary>
        /// <param name="turnBasedListener">(NOTNULL)Listener For Receive GSLive TurnBased System Events</param>
        public void SetListener(GSLiveTurnBasedListener turnBasedListener)
        {            
            if (turnBasedListener != null)
            {
                _turnBasedListener = turnBasedListener;
                var eventListener = new IEventListener((type, payload) =>
                {
                    switch ((EventType) type)
                    { 
                        case EventType.JoinRoom:
                            var join = JsonConvert.DeserializeObject<JoinData>(payload);
                            _turnBasedListener.OnJoin(join,(JoinType)join.JoinType);
                            break;
                        case EventType.LeaveRoom:
                            _turnBasedListener.OnLeave(JsonConvert.DeserializeObject<Leave>(payload));
                            break;    
                        case EventType.Success:
                            _turnBasedListener.OnSuccess();
                            break;
                        case EventType.TakeTurn:
                            _turnBasedListener.OnTakeTurn(JsonConvert.DeserializeObject<Turn>(payload));
                            break;
                        case EventType.ChooseNext:
                            _turnBasedListener.OnChooseNext(JsonConvert.DeserializeObject<Member>(payload));
                            break;
                        case EventType.Finish:
                            _turnBasedListener.OnFinish(JsonConvert.DeserializeObject<Finish>(payload));
                            break;
                        case EventType.Complete:
                            _turnBasedListener.OnComplete(JsonConvert.DeserializeObject<Complete>(payload));
                            break;
                        case EventType.GetUsers:
                            _turnBasedListener.OnRoomMembersDetail(JsonConvert.DeserializeObject<List<Member>>(payload));
                            break;
                        case EventType.GetInviteList:
                            _turnBasedListener.OnInviteInbox(JsonConvert.DeserializeObject<List<Invite>>(payload));
                            break;
                        case EventType.InviteUser:
                            _turnBasedListener.OnInviteSend();
                            break;
                        case EventType.FindUser:
                            _turnBasedListener.OnFindUsers(JsonConvert.DeserializeObject<List<User>>(payload));
                            break;
                        case EventType.ActionInviteReceive:
                            _turnBasedListener.OnInviteReceive(JsonConvert.DeserializeObject<Invite>(payload));
                            break;
                        case EventType.MatchWaiting:
                            _turnBasedListener.OnAutoMatchUpdate(AutoMatchStatus.OnWaiting,JsonConvert.DeserializeObject<List<User>>(payload));
                            break;
                        case EventType.MemberForAutoMatch:
                            _turnBasedListener.OnAutoMatchUpdate(AutoMatchStatus.OnUserJoined,JsonConvert.DeserializeObject<List<User>>(payload));
                            break;
                        case EventType.AvailableRoom:
                            _turnBasedListener.OnAvailableRooms(JsonConvert.DeserializeObject<List<Room>>(payload));
                            break;
                        case EventType.AcceptInvite:
                            break;
                        case EventType.OnConnect:
                            break;
                    }

                }, _turnBasedListener.OnTurnBasedError);

                IsAvailable = true;
                SetEventListener(eventListener);
            }
            else
            {
                LogUtil.LogError(Tag,"Listener Must not be NULL");
            }
        }
        
        
        /// <summary>
        /// Create Room With Option Like : Name , Min , Max , Role , IsPrivate
        /// </summary>
        /// <param name="option">(NOTNULL)Create Room Option</param>
        public void CreateRoom(GSLiveOption.CreateRoomOption option)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            
            if (option == null)
            {
                LogUtil.LogError(Tag, "Option Must not be NULL");
                return;
            }
                   
            if (option.MinPlayer < 2 || option.MaxPlayer > 8)
            {
                LogUtil.LogError(Tag,"Min Player Must grater than 2 , Max Player Must less than 8");
                return;
            }
                        
            var tb = GSLiveProvider.GetGSLiveTB();    
            tb.Call("CreateRoom",
                option.RoomName,
                option.MaxPlayer,
                option.MinPlayer,
                option.Role,
                option.IsPrivate    
            );                
        }
        
        
        /// <summary>
        /// Create AutoMatch With Option Like :  Min , Max , Role 
        /// </summary>
        /// <param name="option">(NOTNULL)AutoMatch Option</param>
        public void AutoMatch(GSLiveOption.AutoMatchOption option)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            
            if (option == null)
            {
                LogUtil.LogError(Tag, "Option Must not be NULL");
                return;
            }
            
            if (option.MinPlayer < 2 || option.MaxPlayer > 8)
            {
                LogUtil.LogError(Tag,"Min Player Must grater than 2 , Max Player Must less than 8");
                return;
            }
            
            var tb = GSLiveProvider.GetGSLiveTB();    
            tb.Call("AutoMatch",
                option.MaxPlayer,
                option.MinPlayer,
                option.Role   
            );  
        }
        
        
        /// <summary>
        /// Join In Room With RoomID
        /// </summary>
        /// <param name="roomId">(NOTNULL)Room's id You Want To Join</param>
        public void JoinRoom(string roomId)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            if (roomId == null)
            {
                LogUtil.LogError(Tag, "RoomId Must not be NULL");
                return;
            }
            var tb = GSLiveProvider.GetGSLiveTB();    
            tb.Call("JoinRoom",roomId);     
        }
        
        
        /// <summary>
        /// Get Available Rooms According To Room's Role  
        /// </summary>
        /// <param name="role">(NOTNULL)Room's Role </param>
        public void GetAvailableRooms(string role)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            
            if (role == null)
            {
                LogUtil.LogError(Tag, "Role Must not be NULL");
                return;
            }

            var tb = GSLiveProvider.GetGSLiveTB();      
            tb.Call("GetAvailableRooms",role);     
        }

       
        /// <summary>
        /// If is your Turn, you can send data to other players using this function.
        /// Also if You Want to Move Your Turn to the Next player
        /// put the next player ID in the function entry
        /// You can use this function several times
        /// </summary>
        /// <param name="data">(NULLABLE)Room's Role </param>
        /// <param name="whoIsNext">(NULLABLE) Next Player's ID </param>
        public void TakeTurn(string data , string whoIsNext)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
     
            var tb = GSLiveProvider.GetGSLiveTB();     
            tb.Call("TakeTurn",data,whoIsNext);
           
        }
        
        
        
        /// <summary>
        /// If it's your turn, you can transfer the turn to the next player without sending data
        /// if whoIsNext Set Null , Server Automatically Selects Next Turn 
        /// </summary>
        /// <param name="whoIsNext">(NULLABLE)Next Player's ID </param>
        public void ChooseNext(string whoIsNext)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
     
            var tb = GSLiveProvider.GetGSLiveTB();     
            tb.Call("ChooseNext",whoIsNext);
           
        }
        
        
        /// <summary>
        /// Leave The Current Room , if whoIsNext Set Null , Server Automatically Selects Next Turn 
        /// </summary>
        /// <param name="whoIsNext">(NULLABLE)(Type : Member's ID) Player's id You Want To Select Next Turn</param>
        public void LeaveRoom(string whoIsNext)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
     
            var tb = GSLiveProvider.GetGSLiveTB();     
            tb.Call("LeaveRoom",whoIsNext);
           
        }
        
        
        /// <summary>
        /// If you want to announce the end of the game, use this function to send the result of your game to other players.
        /// </summary>
        /// <param name="outcomes">(NOTNULL) A set of players and their results</param>
        public void Finish(Dictionary <string,Outcome> outcomes)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            
            if (outcomes == null)
            {
                LogUtil.LogError(Tag, "Outcomes Must not be NULL");
                return;
            }
   
            var tb = GSLiveProvider.GetGSLiveTB();     
            tb.Call("Finish",JsonConvert.SerializeObject(outcomes));
        }
        
        
        /// <summary>
        /// If you would like to confirm one of the results posted by other Players
        /// </summary>
        /// <param name="memberId">(NOTNULL)The Specific player ID</param>
        public void Complete(string memberId)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            
            if (memberId == null)
            {
                LogUtil.LogError(Tag, "MemberId Must not be NULL");
                return;
            }
            
   
            var tb = GSLiveProvider.GetGSLiveTB();     
            tb.Call("Complete",memberId);
        }
        
        
        /// <summary>
        /// Get Room Members Details 
        /// </summary>
        public void GetRoomPlayersDetail()
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
   
            var tb = GSLiveProvider.GetGSLiveTB();     
            tb.Call("GetRoomPlayersDetail");
        }
        
        
        /// <summary>
        /// Get Your Invite Inbox
        /// </summary>
        public void GetInviteInbox()
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var tb = GSLiveProvider.GetGSLiveTB();      
            tb.Call("GetInviteInbox");     
        }
        
        
        /// <summary>
        /// Invite a Specific Player To Specific Room
        /// </summary>
        /// <param name="roomId">(NOTNULL) (Type : RoomID)Room's ID</param>
        /// <param name="userId">(NOTNULL) (Type : UserID)User's ID</param>
        public void InviteUser(string roomId,string userId)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            
            if (roomId == null || userId == null)
            {
                LogUtil.LogError(Tag, "Inputs Must not be NULL");
                return;
            }

            var tb = GSLiveProvider.GetGSLiveTB();      
            tb.Call("InviteUser",roomId,userId);     
        }
        
        
        /// <summary>
        /// Accept a Specific Invite With Invite ID
        /// Note: After accepting the invitation, you will be automatically entered into the game room
        /// </summary>
        /// <param name="inviteId">(NOTNULL) (Type : InviteID) Invite's ID</param>
        public void AcceptInvite(string inviteId)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            
            if (inviteId == null)
            {
                LogUtil.LogError(Tag, "InviteID Must not be NULL");
                return;
            }

            var tb = GSLiveProvider.GetGSLiveTB();      
            tb.Call("AcceptInvite",inviteId);     
        }
        
        
        /// <summary>
        /// Find All Users With Specific NickName
        /// </summary>
        /// <param name="query">(NOTNULL) Player's NickName</param>
        /// <param name="limit">(Max = 15) The Result Limits</param>
        public void FindUser(string query,int limit)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            
            if(query == null)
            {
                LogUtil.LogError(Tag, "Query Must not be NULL");
                return;
            }
            
            if(limit < 0)
            {
                LogUtil.LogError(Tag, "Limit Must be Positive");
                return;
            }

            var tb = GSLiveProvider.GetGSLiveTB();      
            tb.Call("FindUser",query,limit);     
        }
   
    }
#endif
}