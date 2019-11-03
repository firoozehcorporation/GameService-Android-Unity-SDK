// <copyright file="GSLive.cs" company="Firoozeh Technology LTD">
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


/**
* @author Alireza Ghodrati
*/



namespace FiroozehGameServiceAndroid.Core.GSLive
{
#if UNITY_ANDROID
    
    /// <summary>
    /// Represents Game Service MultiPlayer System (GSLive)
    /// </summary>
    public class GSLive
    {
        
        private const string Tag = "GSLive";
        
        public GSLiveRT RealTime { get; private set; }
        public GSLiveTB TurnBased { get; private set; }
        public GSLiveChat Chat { get; private set; }

        
        public GSLive()
        {
            RealTime = new GSLiveRT();
            Chat = new GSLiveChat();
            TurnBased = new GSLiveTB();
        }

        public bool IsRealTimeAvailable()
        {
            return RealTime.IsAvailable;
        }
        
        public bool IsTurnBasedAvailable()
        {
            return TurnBased.IsAvailable;
        }
      
    }
#endif
}