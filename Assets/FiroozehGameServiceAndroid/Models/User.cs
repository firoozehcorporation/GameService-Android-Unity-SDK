namespace FiroozehGameServiceAndroid.Models
{
    [System.Serializable]
    public class User
    {

        public string name { set; get; }

        public string email { set; get; }

        public string id { set; get; }

        public string plan { set; get; }

        public string logo { set; get; }


        public string mobile { set; get; }


        public int point { set; get; }

        public override string ToString()
        {
            return "User{" +
                   "name='" + name + '\'' +
                   ", email='" + email + '\'' +
                   ", id='" + id + '\'' +
                   ", plan='" + plan + '\'' +
                   // ", created=" + created +
                   ", logo='" + logo + '\'' +
                   ", mobile='" + mobile + '\'' +
                   ", point=" + point +
                   '}';
        }


    }
}

