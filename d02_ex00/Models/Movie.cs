using System;
using System.Text.Json.Serialization;

namespace d02_ex00.Models
{
    public class Movie: ISearchable
    {
        [JsonPropertyName("title")] 
        public string Title {get; set; }
        [JsonPropertyName("mpaa_rating")] 
        public string Rating { get; set; }
        [JsonPropertyName("critics_pick")] 
        public int IsCriticsPick { get; set; }
        [JsonPropertyName("summary_short")] 
        public string SummaryShort { get; set; }
        public string Url { get; set; }
        public string TypeMedia { get; set; }

        public override string ToString()
        {
            return "-" + Title.ToUpper() + "\n" +
                   SummaryShort + "\n" + Url;
        }
    }
}
