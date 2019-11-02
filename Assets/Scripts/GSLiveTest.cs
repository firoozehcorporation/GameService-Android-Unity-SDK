using System.Collections.Generic;
using FiroozehGameServiceAndroid.Builders;
using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Core.GSLive;
using FiroozehGameServiceAndroid.Enums;
using FiroozehGameServiceAndroid.Enums.GSLive;
using FiroozehGameServiceAndroid.Enums.GSLive.RT;
using FiroozehGameServiceAndroid.Interfaces.GSLive;
using FiroozehGameServiceAndroid.Interfaces.GSLive.RT;
using FiroozehGameServiceAndroid.Models;
using FiroozehGameServiceAndroid.Models.GSLive;
using FiroozehGameServiceAndroid.Models.GSLive.RT;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;


public class GsLiveRealTimeTest : MonoBehaviour, GSLiveRealTimeListener
{
    public Button CreateRoom;
    public Button JoinRoom;
    public Button LeaveRoom;
    public Button AvailableRoom;
    public Button AutoMatch;
    public Button PlayersInRoom;
    public Button BroadCastToAll;
    public Button BroadCastToOne;



    public InputField Name;
    public InputField Max;
    public InputField Min;
    public InputField Role;


    public Text Logs;
    public Text Errors;

    
    void Start()
    {
        var config = new GameServiceClientConfiguration
                .Builder(LoginType.Normal)
            .SetClientId("mygame")
            .SetClientSecret("h31r1kjwy8lap7lnrwd3x7")
            .IsLogEnable(true)
            .IsNotificationEnable(true)
            .SetNotificationListener(OnJsonData)
            .CheckGameServiceInstallStatus(true)
            .CheckGameServiceOptionalUpdate(false)
            .Build();
        
        FiroozehGameService.ConfigurationInstance(config);
        FiroozehGameService.Run(OnFirstInit,Debug.LogError);
    }

  
    
    private void OnJsonData(string jsonData){
       
    }

    private void OnFirstInit()
    {
        FiroozehGameService.Instance.GSLive.RealTime.SetListener(this);
        
        
        CreateRoom.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.RealTime.CreateRoom(new GSLiveOption.CreateRoomOption
            {
                RoomName = Name.text , Role = Role.text , MinPlayer = int.Parse(Min.text) , MaxPlayer = int.Parse(Max.text) , IsPrivate = false
            });
        });
        
        JoinRoom.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.RealTime.JoinRoom("Room ID");
        });
        
        LeaveRoom.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.RealTime.LeaveRoom();
        });
        
        AvailableRoom.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.RealTime.GetAvailableRooms(Role.text);
        });
        
        AutoMatch.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.RealTime.AutoMatch(new GSLiveOption.AutoMatchOption
            {
                 MinPlayer = int.Parse(Min.text) , MaxPlayer = int.Parse(Max.text) , Role = Role.text         
            });
        });
        
        PlayersInRoom.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.RealTime.GetRoomPlayersDetail();
        });
        
        
        BroadCastToAll.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.RealTime.SendPublicMessage(Name.text);
        });
        
        
        BroadCastToOne.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.RealTime.SendPrivateMessage(Role.text,Name.text);
        });
            
    }
    
    
    


    public void OnJoin(JoinData joinData, JoinType type)
    {
        Logs.text += "OnJoin : "+JsonConvert.SerializeObject(joinData) + "\n\n";

    }

    public void OnMessageReceive(Message message, MessageType type)
    {
        Logs.text += "MessageType : "+ type + "OnMessageReceive : "+JsonConvert.SerializeObject(message) + "\n\n";

    }

   


    public void OnLeave(Leave leave)
    {
        Logs.text += "OnLeave : "+JsonConvert.SerializeObject(leave) + "\n\n";

    }

    public void OnRoomMembersDetail(List<Member> members)
    {
        throw new System.NotImplementedException();
    }

    public void OnAvailableRooms(List<Room> rooms)
    {
        Logs.text += "OnAvailableRooms : "+JsonConvert.SerializeObject(rooms) + "\n\n";

    }

    public void OnAutoMatchUpdate(AutoMatchStatus status, List<User> players)
    {
        
    }

    public void OnInviteInbox(List<Invite> invites)
    {
    }

    public void OnInviteSend()
    {
        
    }

    public void OnFindUsers(List<User> users)
    {
    }


    public void OnAvailablePlayerForAutoMatch(List<User> members)
    {

    }

    public void OnRoomPlayersDetail(List<User> players)
    {
        Logs.text += "OnRoomPlayersDetail : "+JsonConvert.SerializeObject(players) + "\n\n";

    }


    public void OnInviteReceive(Invite invite)
    {
    }

    public void OnSuccess()
    {
        Logs.text += "OnSuccess";
    }

    public void OnRealTimeError(string error)
    {
        Errors.text += error;
    }
}