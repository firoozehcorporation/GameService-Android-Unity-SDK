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
using FiroozehGameServiceAndroid.Interfaces.GSLive;
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
    public class GSLiveRT
    {
        private const string Tag = "GSLive-RealTime";
        private GSLiveType _type = GSLiveType.RealTime;
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

        
        public void SetListener(GSLiveRealTimeListener realTimeListener)
        {            
            if (realTimeListener != null)
            {
                _realTimeListener = realTimeListener;
                var eventListener = new IEventListener((type, payload) =>
                {
                    switch ((EventType) type)
                    {
                        case EventType.CreateRoom:
                            _realTimeListener.OnCreate(JsonConvert.DeserializeObject<RoomData>(payload));
                            break;
                        case EventType.JoinRoom:
                            var join = JsonConvert.DeserializeObject<JoinData>(payload);
                            _realTimeListener.OnJoin(join,(JoinType)join.JoinType);
                            break;
                        case EventType.LeaveRoom:
                            var leave = JsonConvert.DeserializeObject<Message>(payload);
                            _realTimeListener.OnLeave(new Leave {RoomId = leave.RoomId, MemberLeaveId = leave.SenderId});
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
                            _realTimeListener.OnAvailablePlayerForAutoMatch(JsonConvert.DeserializeObject<List<User>>(payload));
                            break;
                        case EventType.MembersDetail:
                            var details = JsonConvert.DeserializeObject<Message>(payload);
                            _realTimeListener.OnRoomPlayersDetail(JsonConvert.DeserializeObject<List<User>>(details.Data));
                            break; 
                        case EventType.ActionGetInviteList:
                            _realTimeListener.OnInviteList(JsonConvert.DeserializeObject<List<Invite>>(payload));
                            break; 
                        case EventType.ActionInviteUser:
                            _realTimeListener.OnInviteSend();
                            break; 
                        case EventType.ActionFindUser:
                            _realTimeListener.OnFindUsers(JsonConvert.DeserializeObject<List<User>>(payload));
                            break; 
                        case EventType.Success:
                            _realTimeListener.OnSuccess();
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

        public void CreateRoom(GSLiveOption.CreateRoomOption option)
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
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
        
        public void AutoMatch(GSLiveOption.AutoMatchOption option)
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
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
        
        public void JoinRoom(string roomId)
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var rt = GSLiveProvider.GetGSLiveRT();    
            rt.Call("JoinRoom",roomId);     
        }
        
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

        public void GetAvailableRooms(string role)
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("GetAvailableRooms",role);     
        }
        
       
        
        public void SendPublicMessage(string data)
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("SendPublicMessage",data);     
        }    
        
        public void SendPrivateMessage(string receiverId,string data)
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            
            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("SendPrivateMessage",receiverId,data);     
        }    
       
        
        public void GetRoomPlayersDetail()
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("GetPlayersDetail");     
        }
        
        public void GetInviteList()
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("GetInviteList");     
        }
        
        public void InviteUser(string roomId,string userId)
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("InviteUser",roomId,userId);     
        }
        
        public void AcceptInvite(string inviteId)
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("AcceptInvite",inviteId);     
        }
        
        public void FindUser(string query,int limit)
        {
            if (_realTimeListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var rt = GSLiveProvider.GetGSLiveRT();      
            rt.Call("FindUser",query,limit);     
        }
        

    }
 #endif
}