using System;
using Newtonsoft.Json;

namespace FiroozehGameServiceAndroid.Models
{
    public class SaveDetails
    {
       
        [JsonProperty("game")]
        public string Game { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("playedtime")]
        public long Playedtime { get; set; }

        [JsonProperty("lastmodify")]
        public DateTimeOffset Lastmodify { get; set; }
    }
}