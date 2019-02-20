using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Helpers;
using UnityEngine;

namespace FiroozehGameServiceAndroid.Builders
{
    public sealed class FiroozehGameServiceInitializer
    {

        private  static FiroozehGameServiceInitializer _singleton;
        private  bool _userLogin= true;
        private  bool _haveNotification= true;
        private bool _checkAppStatus = true;
        private  static string _clientId, _clientSecret;


        private class Builder
        {
            public Builder(string clientId, string clientSecret)
            {
                _clientId = clientId;
                _clientSecret = clientSecret;
            }

            public static FiroozehGameServiceInitializer Build()
            {
                return new FiroozehGameServiceInitializer();
            }
        }



        public static FiroozehGameServiceInitializer With(string clientId, string clientSecret)
        {
            if (_singleton == null)
            {
                if (!string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(clientSecret))
                    return Builder.Build();

                throw new GameServiceException("Invalid ClientId or ClientSecret");
            }
            return _singleton;
        }

        public FiroozehGameServiceInitializer CheckUserLogin(bool checkIt)
        {
            _userLogin = checkIt;
            return this;
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
            if (!_userLogin)
            {
                GameServiceInitializer.Init(_clientId, _clientSecret, s =>
                    {
                        onSuccess.Invoke(new FiroozehGameService(s, _haveNotification));
                    }
                    , e =>
                    {
                        if (_checkAppStatus && e.Equals("GameServiceNotInstalled"))
                            NotInstallDialog.ShowInstallDialog(Application.productName);
                    
                        onError.Invoke(e);
                    });
            }
            else
            {
                FiroozehGameServiceLoginCheck.CheckUserLoginStatus(isLogin
                            =>
                        {
                            if (isLogin)
                            {

                                GameServiceInitializer.Init(_clientId, _clientSecret, s =>
                                    {
                                        onSuccess.Invoke(new FiroozehGameService(s, _haveNotification));
                                    }
                                    , e =>
                                    {
                                        if (_checkAppStatus && e.Equals("GameServiceNotInstalled"))
                                            NotInstallDialog.ShowInstallDialog(Application.productName);
                                        
                                        onError.Invoke(e);
                                    });


                            }
                            else
                                FiroozehGameServiceLoginCheck.ShowLoginUI(r =>
                                {
                                    if(r)
                                        GameServiceInitializer.Init(_clientId, _clientSecret, s =>
                                            {
                                                onSuccess.Invoke(new FiroozehGameService(s, _haveNotification));
                                            }
                                            , e =>
                                            {
                                                if (_checkAppStatus && e.Equals("GameServiceNotInstalled"))
                                                    NotInstallDialog.ShowInstallDialog(Application.productName);
                                         
                                                onError.Invoke(e);
                                            });
                                }, e =>
                                {
                                    if (_checkAppStatus && e.Equals("GameServiceNotInstalled"))
                                        NotInstallDialog.ShowInstallDialog(Application.productName);
                                 
                                    onError.Invoke(e);
                                });
                            
                        },

                        e =>
                        {
                            if (_checkAppStatus && e.Equals("GameServiceNotInstalled"))
                                NotInstallDialog.ShowInstallDialog(Application.productName);
                        
                            onError.Invoke(e);
                        })
                    ;
            }
        }

    }
}
