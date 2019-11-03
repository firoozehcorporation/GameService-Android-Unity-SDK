// <copyright file="GSLiveRT.cs" company="Firoozeh Technology LTD">
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
using FiroozehGameServiceAndroid.Interfaces.GSLive.RT;
using FiroozehGameServiceAndroid.Models;
using FiroozehGameServiceAndroid.Models.GSLive;
using FiroozehGameServiceAndroid.Models.GSLive.RT;
using FiroozehGameServiceAndroid.Utils;
using Newtonsoft.Json;

/**
* @author Alireza Ghodrati
*/


namespace FiroozehGameServiceAndroid.Core.GSLive
{
#if UNITY_ANDROID
    /// <summary>
    /// Represents Game Service Realtime MultiPlayer System
    /// </summary>
    public class GSLiveRT
    {
        private const string Tag = "GSLive-RealTime";
        private GSLiveRealTimeListener _realTimeListener;
        public bool IsAvailable { get; private set; }

        public GSLiveRT()
        {
            
        }
        
        private static void SetEventListener(IEventListener listener)
        {
           var rt = GSLiveProvider.GetGSLiveRT();
           rt.Call("SetListener", listener);
        }

        /// <summary>
        /// Set Listener For Receive GSLive RealTime System Events.
        /// </summary>
        /// <param name="realTimeListener">(NOTNULL)Listener For Receive GSLive RealTime System Events</param>
        public void SetListener(GSLiveRealTimeListener realTimeListener)
        {            
            if (realTimeListener != null)
            {
                _realTimeListener = realTimeListener;
                var eventListener = new IEventListener((type, payload) =>
                {
                    switch ((EventType) type)
                    {
                        case EventType.JoinRoom:
                            var join = JsonConvert.DeserializeObject<JoinData>(payload);
                            _realTimeListener.OnJoin(join,(JoinType)join.JoinType);
                            break;
                        case EventType.LeaveRoom:
                            var leave = JsonConvert.DeserializeObject<Message>(payload);
                            _realTimeListener.OnLeave(new Leave {RoomId = leave.RoomId, MemberLeave = JsonConvert.DeserializeObject<Member>(leave.Data)});
                            break;
                        case EventType.PublicMessageReceive:
                            _realTimeListener.OnMessageReceive(JsonConvert.DeserializeObject<Message>(payload),MessageType.Public);
                            break;
                        case EventType.PrivateMessageReceive:
                            _realTimeListener.OnMessageReceive(JsonConvert.DeserializeObject<Message>(payload),MessageType.Private);
                            break;
                        case EventType.AvailableRoom:
                            _realTimeListener.OnAvailableRooms(JsonConvert.DeserializeObject<List<Room>>(payload));
                            break;
                        case EventType.MemberForAutoMatch:
                            _realTimeListener.OnAutoMatchUpdate(AutoMatchStatus.OnUserJoined,JsonConvert.DeserializeObject<List<User>>(payload));
                            break;
                        case EventType.AutoMatchWaiting:
                            _realTimeListener.OnAutoMatchUpdate(AutoMatchStatus.OnWaiting,JsonConvert.DeserializeObject<List<User>>(payload));
                            break;
                        case EventType.MembersDetail:
                            var details = JsonConvert.DeserializeObject<Message>(payload);
                            _realTimeListener.OnRoomMembersDetail(JsonConvert.DeserializeObject<List<Member>>(details.Data));
                            break; 
                        case EventType.ActionGetInviteList:
                            _realTimeListener.OnInviteInbox(JsonConvert.DeserializeObject<List<Invite>>(payload));
                            break; 
                        case EventType.ActionInviteUser:
                            _realTimeListener.OnInviteSend();
                            break; 
                        case EventType.ActionFindUser:
                            _realTimeListener.OnFindUsers(JsonConvert.DeserializeObject<List<User>>(payload));
                            break; 
                        case EventType.ActionInviteReceive:
                            _realTimeListener.OnInviteReceive(JsonConvert.DeserializeObject<Invite>(payload));
                            break; 
                        case EventType.Success:
                            _realTimeListener.OnSuccess();
                            break;   
                        default:
                            break;
                    }

                }, _realTimeListener.OnRealTimeError);

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
            if (_realTimeListener == null)
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
                        
            var rt = GSLiveProvider.GetGSLiveRT();   
            rt.Call("CreateRoom",
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
            if (_realTimeListener == null)
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
            
            var rt = GSLiveProvider.GetGSLiveRT();       
            rt.Call("AutoMatch",
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
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            
            if (roomId == null)
            {
                LogUtil.LogError(Tag, "RoomId Must not be NULL");
                return;
            }

            var rt = GSLiveProvider.GetGSLiveRT();    
            rt.Call("JoinRoom",roomId);     
        }
        
        /// <summary>
        /// Leave The Current Room
        /// </summary>
        public void LeaveRoom()
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            IsAvailable = false;
            var rt = GSLiveProvider.GetGSLiveRT();     
            rt.Call("LeaveRoom");  
        }

        
        /// <summary>
        /// Get Available Rooms According To Room's Role  
        /// </summary>
        /// <param name="role">(NOTNULL)Room's Role </param>
        public void GetAvailableRooms(string role)
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            
            if (role == null)
            {
                LogUtil.LogError(Tag, "Role Must not be NULL");
                return;
            }

            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("GetAvailableRooms",role);     
        }
        
       
        /// <summary>
        /// Send A Data To All Players in Room. 
        /// </summary>
        /// <param name="data">(NOTNULL) Data To BroadCast </param>
        public void SendPublicMessage(string data)
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            if (data == null)
            {
                LogUtil.LogError(Tag, "Data Must not be NULL");
                return;
            }

            
            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("SendPublicMessage",data);     
        }    
        
        
        /// <summary>
        /// Send A Data To Specific Player in Room. 
        /// </summary>
        /// <param name="receiverId">(NOTNULL) (Type : MemberID)Player's ID</param>
        /// <param name="data">(NOTNULL) Data for Send</param>
        public void SendPrivateMessage(string receiverId,string data)
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            if (receiverId == null || data == null)
            {
                LogUtil.LogError(Tag, "Inputs Must not be NULL");
                return;
            }

            
            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("SendPrivateMessage",receiverId,data);     
        }    
       
        
        /// <summary>
        /// Get Room Members Details 
        /// </summary>
        public void GetRoomMembersDetail()
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("GetPlayersDetail");     
        }
        
        
        /// <summary>
        /// Get Your Invite Inbox
        /// </summary>
        public void GetInviteInbox()
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("GetInviteInbox");     
        }
        
        
        /// <summary>
        /// Invite a Specific Player To Specific Room
        /// </summary>
        /// <param name="roomId">(NOTNULL) (Type : RoomID)Room's ID</param>
        /// <param name="userId">(NOTNULL) (Type : UserID)User's ID</param>
        public void InviteUser(string roomId,string userId)
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            if (roomId == null || userId == null)
            {
                LogUtil.LogError(Tag, "Inputs Must not be NULL");
                return;
            }
            
            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("InviteUser",roomId,userId);     
        }
        
        
        /// <summary>
        /// Accept a Specific Invite With Invite ID
        /// Note: After accepting the invitation, you will be automatically entered into the game room
        /// </summary>
        /// <param name="inviteId">(NOTNULL) (Type : InviteID) Invite's ID</param>
        public void AcceptInvite(string inviteId)
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            
            if (inviteId == null)
            {
                LogUtil.LogError(Tag, "InviteID Must not be NULL");
                return;
            }

            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("AcceptInvite",inviteId);     
        }
        
        /// <summary>
        /// Find All Users With Specific NickName
        /// </summary>
        /// <param name="query">(NOTNULL) Player's NickName</param>
        /// <param name="limit">(Max = 15) The Result Limits</param>
        public void FindUser(string query,int limit)
        {
            if (_realTimeListener == null)
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

            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("FindUser",query,limit);     
        }
        
    }
 #endif
}