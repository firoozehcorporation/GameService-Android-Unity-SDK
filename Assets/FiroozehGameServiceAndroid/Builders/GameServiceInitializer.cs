using FiroozehGameServiceAndroid.Core;

namespace FiroozehGameServiceAndroid.Builders
{
	public static class GameServiceInitializer
	{
#if UNITY_ANDROID
		public static void Init(string clientId
			, string clientSecret
			,bool checkAppStatus
			,DelegateCore.OnSuccessInit onInitGameServiceSuccess
			,DelegateCore.OnError onInitGameServiceError){

			GameServicePluginHandler.InitGameService(clientId, clientSecret,checkAppStatus,onInitGameServiceSuccess,onInitGameServiceError);

		}
#endif

	}
}
