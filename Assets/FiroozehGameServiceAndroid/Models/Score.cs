namespace FiroozehGameServiceAndroid.Models
{
    [System.Serializable]
    public class Score
    {

        public string game { set; get; }

        public User user { set; get; }

        public int value { set; get; }
    
        public int rank { set; get; }
    
        public int tries { set; get; }
    
        public bool me { set; get; }
    

        public override string ToString()
        {
            return "Score{" +
                   "game='" + game + '\'' +
                   ", user='" + user + '\'' +
                   ", Valvalueue=" + value +
                   '}';
        }
    }
}

