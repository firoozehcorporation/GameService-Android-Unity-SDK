using System.Collections.Generic;

namespace FiroozehGameServiceAndroid.Models
{
    [System.Serializable]
    public class LeaderBoardDetails
    {

        public LeaderBoard leaderboard { set; get; }

        public List<Score> scores { set; get; }

        public override string ToString()
        {
            return "LeaderBoardReceiver{" +
                   "leaderboard=" + leaderboard +
                   ", scores=" + scores +
                   '}';
        }
     
    }
}

