using System;
using FiroozehGameServiceAndroid.Builders.App;
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
        private  static GameServiceClientConfiguration _configuration;
        private  const string Tag = "FiroozehGameService";


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
                LogUtil.LogWarning(Tag,"GameService Initialized Before , Do Nothing..");
                return;
            }

            switch (_configuration.InstanceType)
            {
               
                case InstanceType.Native:
                    //NativePluginHandler.Test();
                    // Initializer Native
                    break;
                case InstanceType.Auto:
                    GameServiceAppInitializer.Init(_configuration,OnAppSuccessInit,OnAppErrorInit);       
                    break;
                default:
                    LogUtil.LogError(Tag,"Invalid Instance Type , Auto Type Selected...");
                    GameServiceAppInitializer.Init(_configuration,OnAppSuccessInit,OnAppErrorInit);       
                    break;
            }
             
         
        }

        private static void OnAppSuccessInit(GameServiceApp gameService)
        {
            //Instance = (GameService) gameService;
            IsReady = true;
            LogUtil.LogDebug(Tag,"GameService Is Ready To Use!");
        }
        
        private static void OnAppErrorInit(string error)
        {
            // Switch To Native Mode
            if (error.Equals(ErrorList.GameServiceInstallDialogDismiss)
                || error.Equals(ErrorList.GameServiceUpdateDialogDismiss)
                || error.Equals(ErrorList.GameServiceNotInstalled))
            {
                // Native Mode Call
            }
            else
            _errorAction.Invoke(error);
        }
    }
}
