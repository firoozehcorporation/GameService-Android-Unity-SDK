using FiroozehGameServiceAndroid.Builders;
using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Enums;
using FiroozehGameServiceAndroid.Enums.GSLive;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        
        var config = new GameServiceClientConfiguration
        .Builder(LoginType.Normal)
            .SetClientId("mygame")
            .SetClientSecret("h31r1kjwy8lap7lnrwd3x7")
            .SetObbDataTag("Your Data Tag")
            .IsLogEnable(true)
            .IsNotificationEnable(true)
            .SetNotificationListener(onJsonData)
            .CheckGameServiceInstallStatus(true)
            .CheckGameServiceOptionalUpdate(false)
            .Build();
        
        FiroozehGameService.ConfigurationInstance(config);
        FiroozehGameService.Run(OnFirstInit,Debug.LogError);
        

    }
    
    private static void onJsonData(string jsonData){
       
    }

    private static void OnFirstInit()
    {
        //FiroozehGameService.Instance.GSLive.RealTime.SetListener(this);
        //FiroozehGameService.Instance.GSLive.TurnBased.SetListener(this);
        //FiroozehGameService.Instance.GSLive.Chat.SetListener(this);

        // Get Last Save , Get LeaderBoard List & ...
    }

}