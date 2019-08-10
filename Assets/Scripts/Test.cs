using FiroozehGameServiceAndroid.Builders;
using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Enums;
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
        // Get Last Save , Get LeaderBoard List & ...
    }

}