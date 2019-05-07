using FiroozehGameServiceAndroid.Core;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Utils
{
    public sealed class LogUtil
    {
        private static readonly string TAG = "FiroozehGameServiceLogUtil";
        private static bool _isLogEnable;

        public static void InitialLogger(GameServiceClientConfiguration configuration)
        {
            _isLogEnable = configuration.EnableLog;
        }
        
        public static void LogWarning(string warning)
        {
            if(_isLogEnable)
            Debug.unityLogger.LogWarning(TAG,warning);
        }

        public static void LogError(string error)
        {
            if(_isLogEnable)
            Debug.unityLogger.LogWarning(TAG,error);
        }
    }
}