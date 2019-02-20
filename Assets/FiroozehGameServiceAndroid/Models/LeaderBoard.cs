namespace FiroozehGameServiceAndroid.Models
{
    [System.Serializable]
    public class LeaderBoard
    {


        public string name { set; get; }

        public string key { set; get; }

        public bool status { set; get; }

        public string image { set; get; }

        public int from { set; get; }

        public int to { set; get; }

        public int order { set; get; }

        public string game { set; get; }


        public override string ToString()
        {
            return "LeaderBoard{" +
                   "name='" + name + '\'' +
                   ", key='" + key + '\'' +
                   ", status=" + status +
                   ", image='" + image + '\'' +
                   ", from=" + from +
                   ", to=" + to +
                   ", order=" + order +
                   ", game='" + game + '\'' +
                   '}';
        }
    }
}
