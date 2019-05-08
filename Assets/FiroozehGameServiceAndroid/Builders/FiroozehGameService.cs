using System;
using FiroozehGameServiceAndroid.Builders.App;
using FiroozehGameServiceAndroid.Builders.Native;
using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Core.Native;
using FiroozehGameServiceAndroid.Enums;
using FiroozehGameServiceAndroid.Utils;

namespace FiroozehGameServiceAndroid.Builders
{
    
    
    public sealed class FiroozehGameService
    {

        public static GameService Instance;
        public static bool IsReady;


        private  static Action<string> _errorAction;
        public   static GameServiceClientConfiguration Configuration;
        private  const string Tag = "FiroozehGameService";


        public static void ConfigurationInstance(GameServiceClientConfiguration configuration)
        {  
            Configuration = configuration;     
        }

        public static void Run(Action<string> onError)
        {
            LogUtil.InitialLogger(Configuration);
            _errorAction = onError;

            
            if (Instance != null)
            {
                LogUtil.LogWarning(Tag,"GameService Initialized Before , Do Nothing..");
                return;
            }

            switch (Configuration.InstanceType)
            {
             
                case InstanceType.Native:
                    GameServiceNativeInitializer.Init(Configuration,OnSuccessInit,OnErrorInit);
                    break;
                case InstanceType.Auto:
                    GameServiceAppInitializer.Init(Configuration,OnSuccessInit,OnErrorInit);       
                    break;
                default:
                    LogUtil.LogError(Tag,"Invalid Instance Type , Auto Type Selected...");
                    GameServiceAppInitializer.Init(Configuration,OnSuccessInit,OnErrorInit);       
                    break;
            }
             
         
        }

        private static void OnSuccessInit(GameService gameService)
        {
            //Instance = (GameService) gameService;
            IsReady = true;
            LogUtil.LogDebug(Tag,"GameService Is Ready To Use!");
        }
        
        private static void OnErrorInit(string error)
        {
            // Switch To Native Mode
            if (error.Equals(ErrorList.GameServiceInstallDialogDismiss)
                || error.Equals(ErrorList.GameServiceUpdateDialogDismiss)
                || error.Equals(ErrorList.GameServiceNotInstalled))
            {
                // Native Mode Call
                GameServiceNativeInitializer.Init(Configuration,OnSuccessInit,OnErrorInit);
            }
            else
            _errorAction.Invoke(error);
        }

      
    }
}
