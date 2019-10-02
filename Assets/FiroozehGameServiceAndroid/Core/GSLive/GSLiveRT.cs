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
        private IGSLiveListener _listener;
        public bool IsAvailable { get; private set; }

        public GSLiveRT()
        {
            
        }
        
        private static void SetEventListener(IEventListener listener)
        {
           var multi = GSLiveProvider.GetGSLive();
           multi.Call("SetListener", listener);
        }

        
        public void SetGSLiveListener(IGSLiveListener listener)
        {            
            if (listener != null)
            {
                _listener = listener;
                var eventListener = new IEventListener((type, payload) =>
                {
                    switch ((EventType) type)
                    {
                        case EventType.CreateRoom:
                            _listener.OnCreate(JsonConvert.DeserializeObject<RoomData>(payload));
                            break;
                        case EventType.JoinRoom:
                            var join = JsonConvert.DeserializeObject<JoinData>(payload);
                            _listener.OnJoin(join,(JoinType)join.JoinType);
                            break;
                        case EventType.LeaveRoom:
                            var leave = JsonConvert.DeserializeObject<Message>(payload);
                            _listener.OnLeave(new Leave {RoomId = leave.RoomId, MemberLeaveId = leave.SenderId});
                            break;
                        case EventType.PublicMessageReceive:
                            _listener.OnMessageReceive(JsonConvert.DeserializeObject<Message>(payload),MessageType.Public);
                            break;
                        case EventType.PrivateMessageReceive:
                            _listener.OnMessageReceive(JsonConvert.DeserializeObject<Message>(payload),MessageType.Private);
                            break;
                        case EventType.AvailableRoom:
                            _listener.OnAvailableRooms(JsonConvert.DeserializeObject<List<Room>>(payload));
                            break;
                        case EventType.MemberForAutoMatch:
                            _listener.OnAvailablePlayerForAutoMatch(JsonConvert.DeserializeObject<List<User>>(payload));
                            break;
                        case EventType.MembersDetail:
                            var details = JsonConvert.DeserializeObject<Message>(payload);
                            _listener.OnRoomPlayersDetail(JsonConvert.DeserializeObject<List<User>>(details.Data));
                            break;
                        case EventType.Success:
                            _listener.OnSuccess();
                            break;
                    }

                }, _listener.OnError);

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
            if (_listener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
                   
            if (option.MinPlayer < 2 || option.MaxPlayer > 8)
            {
                LogUtil.LogError(Tag,"Min Player Must grater than 2 , Max Player Must less than 8");
                return;
            }
                        
            var multi = GSLiveProvider.GetGSLive();   
            multi.Call("CreateRoom",
                option.RoomName,
                option.MaxPlayer,
                option.MinPlayer,
                option.Role,
                option.IsPrivate    
                );                
        }
        
        public void AutoMatch(GSLiveOption.AutoMatchOption option)
        {
            if (_listener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            

            if (option.MinPlayer < 2 || option.MaxPlayer > 8)
            {
                LogUtil.LogError(Tag,"Min Player Must grater than 2 , Max Player Must less than 8");
                return;
            }
            
            var multi = GSLiveProvider.GetGSLive();       
            multi.Call("AutoMatch",
                option.MaxPlayer,
                option.MinPlayer,
                option.Role   
            );  
        }
        
        public void JoinRoom(string roomId)
        {
            if (_listener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var multi = GSLiveProvider.GetGSLive();    
            multi.Call("JoinRoom",roomId);     
        }
        
        public void LeaveRoom()
        {
            if (_listener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            IsAvailable = false;
            var multi = GSLiveProvider.GetGSLive();     
            multi.Call("LeaveRoom");  
        }

        public void GetAvailableRooms(string role)
        {
            if (_listener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var multi = GSLiveProvider.GetGSLive();      
            multi.Call("GetAvailableRooms",role);     
        }
        
        
        public void SendPublicMessage(string data)
        {
            if (_listener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var multi = GSLiveProvider.GetGSLive();      
            multi.Call("SendPublicMessage",data);     
        }    
        
        public void SendPrivateMessage(string receiverId,string data)
        {
            if (_listener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            
            var multi = GSLiveProvider.GetGSLive();      
            multi.Call("SendPrivateMessage",receiverId,data);     
        }    
        
        
        public void GetRoomPlayersDetail()
        {
            if (_listener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var multi = GSLiveProvider.GetGSLive();      
            multi.Call("GetPlayersDetail");     
        }      
    }
 #endif
}