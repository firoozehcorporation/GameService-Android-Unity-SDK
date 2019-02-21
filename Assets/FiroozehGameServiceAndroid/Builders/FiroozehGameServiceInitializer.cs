using FiroozehGameServiceAndroid.Core;

namespace FiroozehGameServiceAndroid.Builders
{
    public sealed class FiroozehGameServiceInitializer
    {

        private  static FiroozehGameServiceInitializer _singleton;
        private  bool _haveNotification= true;
        private  bool _checkAppStatus = true;
        private  static string _clientId, _clientSecret;
        private string TAG = "FiroozehGameServiceInitializer";


        private class Builder
        {
            public Builder(string clientId, string clientSecret)
            {
                _clientId = clientId;
                _clientSecret = clientSecret;
            }

            public FiroozehGameServiceInitializer Build()
            {
                return new FiroozehGameServiceInitializer();
            }
        }



        public static FiroozehGameServiceInitializer With(string clientId, string clientSecret)
        {
            if (_singleton != null) return _singleton;
            if (!string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(clientSecret))
                return new Builder(clientId, clientSecret).Build();

            throw new GameServiceException("Invalid ClientId or ClientSecret");
        }

        public FiroozehGameServiceInitializer IsNotificationEnable(bool enable)
        {
            _haveNotification = enable;
            return this;
        }
    
        public FiroozehGameServiceInitializer CheckGameServiceInstallStatus(bool check)
        {
            _checkAppStatus = check;
            return this;
        }



        public void Init(DelegateCore.OnSuccessInitService onSuccess,DelegateCore.OnError onError)
        {
           
                FiroozehGameServiceLoginCheck.CheckUserLoginStatus(_checkAppStatus,isLogin
                            =>
                        {
                            if (isLogin)
                            {

                                GameServiceInitializer.Init(_clientId, _clientSecret,_checkAppStatus, s =>
                                    {
                                        onSuccess.Invoke(new FiroozehGameService(s, _haveNotification));
                                    }
                                    , onError.Invoke);


                            }
                            else
                                FiroozehGameServiceLoginCheck.ShowLoginUI(_checkAppStatus,r =>
                                {
                                    if(r)
                                        GameServiceInitializer.Init(_clientId, _clientSecret,_checkAppStatus,
                                            s =>
                                            {
                                                onSuccess.Invoke(new FiroozehGameService(s, _haveNotification));
                                            }
                                            , onError.Invoke);
                                }, onError.Invoke);
                            
                        },

                        onError.Invoke)
                    ;
           
        }

    }
}
