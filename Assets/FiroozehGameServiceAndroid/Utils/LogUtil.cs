using FiroozehGameServiceAndroid.Core;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Utils
{
    public sealed class LogUtil
    {
        private const string Tag = "FiroozehGameServiceLogUtil";
        private static bool _isLogEnable;

        public static void InitialLogger(GameServiceClientConfiguration configuration)
        {
            _isLogEnable = configuration.EnableLog;
        }

        public static void LogDebug(string where,string debug)
        {
            if(_isLogEnable)
                Debug.unityLogger.Log(where,debug);
        }
        
        public static void LogWarning(string where,string warning)
        {
            if(_isLogEnable)
            Debug.unityLogger.LogWarning(where,warning);
        }

        public static void LogError(string where,string error)
        {
            if(_isLogEnable)
            Debug.unityLogger.LogWarning(where,error);
        }
    }
}