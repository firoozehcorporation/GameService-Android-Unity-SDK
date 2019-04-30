using FiroozehGameServiceAndroid.Core;

namespace FiroozehGameServiceAndroid.Builders
{
    public sealed class FiroozehGameServiceInitializer
    {

        private  static FiroozehGameServiceInitializer _singleton;
        private  static FiroozehGameService _gameService;
        private  bool _haveNotification= true;
        private  bool _checkAppStatus = true;
        private  bool _checkOptionalUpdate = true;    
        private  static string _clientId, _clientSecret;
        private  string TAG = "FiroozehGameServiceInitializer";


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
        
        public FiroozehGameServiceInitializer CheckGameServiceOptionalUpdate(bool check)
        {
            _checkOptionalUpdate = check;
            return this;
        }

        public void Init(DelegateCore.OnSuccessInitService onSuccess,DelegateCore.OnError onError)
        {

            if (_gameService == null)
            {
                FiroozehGameServiceLoginCheck.CheckUserLoginStatus(
                    _checkAppStatus
                    , _checkOptionalUpdate
                    , isLogin =>
                    {
                        if (isLogin)
                            GameServiceInitializer.Init(_clientId, _clientSecret, s =>
                                {
                                    _gameService = new FiroozehGameService(s, _haveNotification);
                                    onSuccess.Invoke(_gameService);
                                }
                                , onError.Invoke);
                        else
                            FiroozehGameServiceLoginCheck.ShowLoginUI(
                                _checkAppStatus
                                , _checkOptionalUpdate
                                , r =>
                                {
                                    if (r)
                                        GameServiceInitializer.Init(
                                            _clientId,
                                            _clientSecret,
                                            s =>
                                            {
                                                _gameService = new FiroozehGameService(s, _haveNotification);
                                                onSuccess.Invoke(_gameService);
                                            }
                                            , onError.Invoke);
                                }, onError.Invoke);

                    },
                    onError.Invoke);
            }
            else onSuccess.Invoke(_gameService);
        }

    }
}
