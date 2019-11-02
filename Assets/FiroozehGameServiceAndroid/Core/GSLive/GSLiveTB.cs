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
        
        
        public void CreateRoom(GSLiveOption.CreateRoomOption option)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
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
        
        
        public void AutoMatch(GSLiveOption.AutoMatchOption option)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
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
        
        
        public void JoinRoom(string roomId)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var tb = GSLiveProvider.GetGSLiveTB();    
            tb.Call("JoinRoom",roomId);     
        }
        
        
        public void GetAvailableRooms(string role)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var tb = GSLiveProvider.GetGSLiveTB();      
            tb.Call("GetAvailableRooms",role);     
        }

       
    
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
        
        
        public void Finish(Dictionary <string,Outcome> outcomes)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
   
            var tb = GSLiveProvider.GetGSLiveTB();     
            tb.Call("Finish",JsonConvert.SerializeObject(outcomes));
        }
        
        
        public void Complete(string memberId)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }
   
            var tb = GSLiveProvider.GetGSLiveTB();     
            tb.Call("Complete",memberId);
        }
        
        
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
        
        
        public void InviteUser(string roomId,string userId)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var tb = GSLiveProvider.GetGSLiveTB();      
            tb.Call("InviteUser",roomId,userId);     
        }
        
        
        public void AcceptInvite(string inviteId)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var tb = GSLiveProvider.GetGSLiveTB();      
            tb.Call("AcceptInvite",inviteId);     
        }
        
        
        public void FindUser(string query,int limit)
        {
            if (_turnBasedListener == null)
            {
                LogUtil.LogError(Tag, "Listener Must not be NULL");
                return;
            }

            var tb = GSLiveProvider.GetGSLiveTB();      
            tb.Call("FindUser",query,limit);     
        }
   
    }
#endif
}