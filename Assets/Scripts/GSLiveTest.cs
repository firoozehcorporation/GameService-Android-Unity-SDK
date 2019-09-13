using System.Collections.Generic;
using FiroozehGameServiceAndroid.Builders;
using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Core.GSLive;
using FiroozehGameServiceAndroid.Enums;
using FiroozehGameServiceAndroid.Interfaces.GSLive;
using FiroozehGameServiceAndroid.Models;
using FiroozehGameServiceAndroid.Models.GSLive;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;


public class GsLiveTest : MonoBehaviour, IGsLiveListener
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
        FiroozehGameService.Instance.GSLive.SetGSLiveOptions(GSLiveType.RealTime,this);
        
        
        CreateRoom.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.CreateRoom(new GSLiveOption.CreateRoomOption
            {
                RoomName = Name.text , Role = Role.text , MinPlayer = int.Parse(Min.text) , MaxPlayer = int.Parse(Max.text) , IsPrivate = false
            });
        });
        
        JoinRoom.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.JoinRoom("Room ID");
        });
        
        LeaveRoom.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.LeaveRoom();
        });
        
        AvailableRoom.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.GetAvailableRooms(Role.text);
        });
        
        AutoMatch.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.AutoMatch(new GSLiveOption.AutoMatchOption
            {
                 MinPlayer = int.Parse(Min.text) , MaxPlayer = int.Parse(Max.text) , Role = Role.text         
            });
        });
        
        PlayersInRoom.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.GetRoomPlayersDetail();
        });
        
        
        BroadCastToAll.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.BroadCastToAll(Name.text);
        });
        
        
        BroadCastToOne.onClick.AddListener(() =>
        {
            FiroozehGameService.Instance.GSLive.BroadCastToOne(Role.text,Name.text);
        });
            
    }
    
    
    

    public void OnCreate(RoomData room)
    {
        Logs.text += "OnCreate : "+JsonConvert.SerializeObject(room) + "\n\n";
    }

    public void OnJoin(JoinData joinData)
    {
        Logs.text += "OnJoin : "+JsonConvert.SerializeObject(joinData) + "\n\n";

    }


    public void OnBroadCastReceive(BroadCast broadCast, BroadCastType type)
    {
        Logs.text += "BroadCastType : "+ type + "OnBroadCastReceive : "+JsonConvert.SerializeObject(broadCast) + "\n\n";

    }


    public void OnLeave(Leave leave)
    {
        Logs.text += "OnLeave : "+JsonConvert.SerializeObject(leave) + "\n\n";

    }

    public void OnAvailableRooms(List<Room> rooms)
    {
        Logs.text += "OnAvailableRooms : "+JsonConvert.SerializeObject(rooms) + "\n\n";

    }

   

    public void OnAvailablePlayerForAutoMatch(List<User> members)
    {
        Logs.text += "OnAvailablePlayerForAutoMatch : "+JsonConvert.SerializeObject(members) + "\n\n";

    }

    public void OnRoomPlayersDetail(List<User> players)
    {
        Logs.text += "OnRoomPlayersDetail : "+JsonConvert.SerializeObject(players) + "\n\n";

    }

    public void OnSuccess()
    {
        Logs.text += "OnSuccess";
    }

    public void OnError(string error)
    {
        Errors.text += error;
    }
}