// <copyright file="GSLive.cs" company="Firoozeh Technology LTD">
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
using FiroozehGameServiceAndroid.Enums;
using FiroozehGameServiceAndroid.Interfaces.GSLive;
using FiroozehGameServiceAndroid.Models;
using FiroozehGameServiceAndroid.Models.GSLive;
using FiroozehGameServiceAndroid.Utils;
using Newtonsoft.Json;
using UnityEngine;
using EventType = FiroozehGameServiceAndroid.Enums.EventType;

/**
* @author Alireza Ghodrati
*/



namespace FiroozehGameServiceAndroid.Core.GSLive
{
#if UNITY_ANDROID
    
    public class GSLive
    {
        public GSLive()
        {
            
        }
        private const string Tag = "GSLive";
        private GSLiveType _type = GSLiveType.NotSet;
        private IGsLiveListener _listener;
    
        private static void SetEventListener(IEventListener listener)
        {
           var multi = GSLiveProvider.GetGSLive();
            multi.Call("SetListener", listener);
        }

        
        public void SetGSLiveOptions(GSLiveType gsLiveType,IGsLiveListener listener)
        {
            _type = gsLiveType;
            
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
                            _listener.OnJoin(JsonConvert.DeserializeObject<JoinData>(payload));
                            break;
                        case EventType.LeaveRoom:
                            var leave = JsonConvert.DeserializeObject<BroadCast>(payload);
                            _listener.OnLeave(new Leave {RoomId = leave.RoomId, MemberLeaveId = leave.SenderId});
                            break;
                        case EventType.BroadCastToAll:
                            _listener.OnBroadCastReceive(JsonConvert.DeserializeObject<BroadCast>(payload),BroadCastType.ToAll);
                            break;
                        case EventType.BroadCastToOne:
                            _listener.OnBroadCastReceive(JsonConvert.DeserializeObject<BroadCast>(payload),BroadCastType.ToOne);
                            break;
                        case EventType.AvailableRoom:
                            _listener.OnAvailableRooms(JsonConvert.DeserializeObject<List<Room>>(payload));
                            break;
                        case EventType.MemberForAutoMatch:
                            _listener.OnAvailablePlayerForAutoMatch(JsonConvert.DeserializeObject<List<User>>(payload));
                            break;
                        case EventType.MembersDetail:
                            var details = JsonConvert.DeserializeObject<BroadCast>(payload);
                            _listener.OnRoomPlayersDetail(JsonConvert.DeserializeObject<List<User>>(details.Data));
                            break;
                        case EventType.Success:
                            _listener.OnSuccess();
                            break;
                    }

                }, _listener.OnError);

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
            
            if (_type == GSLiveType.NotSet)
            {
                LogUtil.LogError(Tag,"You Must Set GSLiveType");
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
                option.IsPrivate,
                (int)_type
                );                
        }
        
        public void AutoMatch(GSLiveOption.AutoMatchOption option)
        {
            if (_listener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
            
            if (_type == GSLiveType.NotSet)
            {
                LogUtil.LogError(Tag,"You Must Set GSLiveType");
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
                option.Role,
                (int)_type
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
        
        
        public void BroadCastToAll(string data)
        {
            if (_listener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var multi = GSLiveProvider.GetGSLive();      
            multi.Call("BroadCastToAll",data);     
        }    
        
        public void BroadCastToOne(string receiverId,string data)
        {
            if (_listener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            
            var multi = GSLiveProvider.GetGSLive();      
            multi.Call("BroadCastToOne",receiverId,data);     
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