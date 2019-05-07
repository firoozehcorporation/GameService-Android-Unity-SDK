using System;
using FiroozehGameServiceAndroid.Builders.App;
using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Enums;
using FiroozehGameServiceAndroid.Utils;

namespace FiroozehGameServiceAndroid.Builders
{
    
    
    public sealed class FiroozehGameService
    {

        public static GameService Instance;
        public static bool IsReady;


        private  static InstanceType _instanceType;
        private  static Action<string> _errorAction;
        private  static GameServiceClientConfiguration _configuration;
        private  string TAG = "FiroozehGameService";


        public static void ConfigurationInstance(GameServiceClientConfiguration configuration)
        {  
            _configuration = configuration;     
        }

        public static void Run(Action<string> onError)
        {
            LogUtil.InitialLogger(_configuration);
            _errorAction = onError;

            
            if (Instance != null)
            {
                LogUtil.LogWarning("GameService Initialized Before , Do Nothing..");
                return;
            } 
            
            
             
            if (DeviceInformationUtil.IsGameServiceAppInstalled())
            {
                _instanceType = InstanceType.App;
                GameServiceAppInitializer.Init(_configuration,OnSuccessInit,OnErrorInit);       
            }
            else
            {
                _instanceType = InstanceType.Native;
            }
        }

        private static void OnSuccessInit(GameService gameService)
        {
            Instance = gameService;
            IsReady = true;
        }
        
        private static void OnErrorInit(string error)
        {
            _errorAction.Invoke(error);
        }
        
        
        

    }
}
