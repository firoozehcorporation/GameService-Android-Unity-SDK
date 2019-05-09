using FiroozehGameServiceAndroid.Builders;
using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Enums;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        
        var config = new GameServiceClientConfiguration
        .Builder(InstanceType.Auto)
            .SetClientId("mygame")
            .SetClientSecret("h31r1kjwy8lap7lnrwd3x7")
            .IsLogEnable(true)
            .IsNotificationEnable(true)
            .CheckGameServiceInstallStatus(true)
            .CheckGameServiceOptionalUpdate(false)
            .Build();
        
        FiroozehGameService.ConfigurationInstance(config);
        FiroozehGameService.Run(OnFirstInit,Debug.LogError);

    }

    private static void OnFirstInit()
    {
        // Get Last Save , Get LeaderBoard List & ...
    }

}