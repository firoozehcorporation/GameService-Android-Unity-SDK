namespace FiroozehGameServiceAndroid.Models
{
    [System.Serializable]
    public class User
    {

        public string name { set; get; }

        public string logo { set; get; }

        public int point { set; get; }

        public override string ToString()
        {
            return "User{" +
                   "name='" + name + '\'' +
                   ", logo='" + logo + '\'' +
                   ", point=" + point +
                   '}';
        }


    }
}

