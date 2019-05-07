namespace FiroozehGameServiceAndroid.Core
{
    public class GameServiceClientConfiguration
    {
        
        public static GameServiceClientConfiguration DefaultConfiguration 
        = new Builder().Build();
        
        private readonly bool _haveNotification;
        private readonly bool _checkAppStatus;
        private readonly bool _checkOptionalUpdate;    
        private readonly string _clientId, _clientSecret;


        private GameServiceClientConfiguration(Builder builder)
        {
            _haveNotification = builder.HaveNotification;
            _checkAppStatus = builder.CheckAppStatus;
            _clientId = builder.ClientId;
            _clientSecret = builder.ClientSecret;
            _checkOptionalUpdate = builder.CheckOptionalUpdate;

        }
        
        public class Builder
        {
            private  bool _haveNotification= true;
            private  bool _checkAppStatus = true;
            private  bool _checkOptionalUpdate = false;    
            private  string _clientId, _clientSecret;

            public Builder SetClientId(string clientId)
            {
                _clientId = clientId;
                return this;
            }
            
            public Builder SetClientSecret(string clientSecret)
            {
                _clientId = clientSecret;
                return this;
            }

            public Builder IsNotificationEnable(bool isEnable)
            {
                _haveNotification = isEnable;
                return this;
            }

            public Builder CheckGameServiceInstallStatus(bool check)
            {
                _checkAppStatus = check;
                return this;
            }
            
            public Builder CheckGameServiceOptionalUpdate(bool check)
            {
                _checkOptionalUpdate = check;
                return this;
            }
            

            public GameServiceClientConfiguration Build()
            {
                return new GameServiceClientConfiguration(this);
            }

            public bool HaveNotification
            {
                get { return _haveNotification; }
            }

            public bool CheckAppStatus
            {
                get { return _checkAppStatus; }
            }

            public bool CheckOptionalUpdate
            {
                get { return _checkOptionalUpdate; }
            }

            public string ClientId
            {
                get { return _clientId; }
            }

            public string ClientSecret
            {
                get { return _clientSecret; }
            }
        }
    }
}