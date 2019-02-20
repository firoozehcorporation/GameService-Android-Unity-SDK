
using System;

[Serializable]
public class Achievement
{

    public string name { set; get; }
    public string key { set; get; }
    public string desc { set; get; }
    public int point { set; get; }
    public string image { set; get; }
    public bool status { set; get; }
    public string game { set; get; }
    public bool earned { set; get; }
    public override string ToString()
    {
        return "Achievement{" +
               "name='" + name + '\'' +
               ", key='" + key + '\'' +
               ", desc='" + desc + '\'' +
               ", point=" + point +
               ", image='" + image + '\'' +
               ", status=" + status +
               ", game='" + game + '\'' +
               ", earned=" + earned +
               '}';
    }
}

