using System;

namespace FiroozehGameServiceAndroid.Core
{
    public class GameServiceException : Exception {


        public GameServiceException(string msg)
            : base("GameServiceException Happened With \""+ msg+ "\" Message.")
        {
        
        }

    }
}
