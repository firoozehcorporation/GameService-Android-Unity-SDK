using FiroozehGameServiceAndroid.Builders;
using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Enums;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        
        var config = new GameServiceClientConfiguration.Builder(InstanceType.Auto)
            .SetClientId("Flappy_Bird")
            .SetClientSecret("z040ye7nv9grgtn292p29")
            .IsLogEnable(true)
            .IsNotificationEnable(true)
            .CheckGameServiceInstallStatus(true)
            .CheckGameServiceOptionalUpdate(false)
            .Build();
        
        FiroozehGameService.ConfigurationInstance(config);
        FiroozehGameService.Run(Debug.LogError);

    }

    private void Update()
    {
        FiroozehGameService.Instance.GetSDKVersion(v=>{},e=>{});
    }
}