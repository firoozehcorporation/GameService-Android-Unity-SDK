// <copyright file="GameServiceClientConfiguration.cs" company="Firoozeh Technology LTD">
// Copyright (C) 2019 Firoozeh Technology LTD. All Rights Reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>


using FiroozehGameServiceAndroid.Core;
using FiroozehGameServiceAndroid.Enums;
using FiroozehGameServiceAndroid.Enums.GSLive;

/**
* @author Alireza Ghodrati
*/


namespace FiroozehGameServiceAndroid.Builders
{
    #if UNITY_ANDROID
    /// <summary>
    /// Represents ClientConfiguration For Game Service 
    /// </summary>
    public class GameServiceClientConfiguration
    {
        
        private readonly bool _haveNotification;
        private readonly bool _checkAppStatus;
        private readonly bool _checkOptionalUpdate;
        private readonly bool _enableLog;
        private readonly string _downloadTag; 
        private readonly string _clientId, _clientSecret;
        private readonly DelegateCore.NotificationListener _notificationListener;
        public LoginType LoginType { get; set; }

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

        public bool EnableLog
        {
            get { return _enableLog; }
        }

        public string ClientId
        {
            get { return _clientId; }
        }

        public string ClientSecret
        {
            get { return _clientSecret; }
        }
        
        public string DownloadTag
        {
            get { return _downloadTag; }
        }
        
        public DelegateCore.NotificationListener NotificationListener
        {
            get { return _notificationListener; }
        }


        private GameServiceClientConfiguration(Builder builder)
        {
            _haveNotification = builder.HaveNotification;
            _checkAppStatus = builder.CheckAppStatus;
            _clientId = builder.ClientId;
            _clientSecret = builder.ClientSecret;
            _checkOptionalUpdate = builder.CheckOptionalUpdate;
            _enableLog = builder.EnableLog;
            _downloadTag = builder.DownloadTag;
            _notificationListener = builder.NotificationListener;
            LoginType = builder.LoginType;

        }
        
        public class Builder
        {
            private  bool _haveNotification= true;
            private  bool _checkAppStatus = true;
            private  bool _checkOptionalUpdate;    
            private  bool _enableLog;
            private string _clientId, _clientSecret;
            private string _downloadTag;
            private readonly LoginType _loginType ;
            private DelegateCore.NotificationListener _notificationListener;


            public Builder(LoginType loginType)
            {
                _loginType = loginType;
            }

            public Builder SetClientId(string clientId)
            {
                _clientId = clientId;
                return this;
            }
            
            public Builder SetClientSecret(string clientSecret)
            {
                _clientSecret = clientSecret;
                return this;
            }

            public Builder IsNotificationEnable(bool isEnable)
            {
                _haveNotification = isEnable;
                return this;
            }

            public Builder SetNotificationListener(DelegateCore.NotificationListener notificationListener)
            {
                _notificationListener = notificationListener;
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

            public Builder IsLogEnable(bool isEnable)
            {
                _enableLog = isEnable;
                return this;
            }

        
            public Builder SetObbDataTag(string dataTag)
            {
                _downloadTag = dataTag;
                return this;
            }
            

            public GameServiceClientConfiguration Build()
            {
                return new GameServiceClientConfiguration(this);
            }

            public string DownloadTag
            {
                get { return _downloadTag; }
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

            public bool EnableLog
            {
                get { return _enableLog; }
            }

            public DelegateCore.NotificationListener NotificationListener
            {
                get { return _notificationListener; }
            }

            public LoginType LoginType
            {
                get { return _loginType; }
            }
        }
    }
    #endif
}