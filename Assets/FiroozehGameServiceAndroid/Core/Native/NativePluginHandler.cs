namespace FiroozehGameServiceAndroid.Core.Native
{
    public static class NativePluginHandler
    {

        public static void Test()
        {
            var unityActivity = NativePluginProvider.GetUnityActivity();
            var logoShower = NativePluginProvider.GetNativeHandlerClass();
            
            logoShower.CallStatic("run",unityActivity);

        }
        
    }
}
