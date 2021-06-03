using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace d02_ex00.Models
{
    public class Book : ISearchable
    { 
        public string Author { get; set; }
        public string SummaryShort { get; set; }
        [JsonPropertyName("title")]
        public string Title {get; set; }
        [JsonPropertyName("rank")] public int Rank { get; set; }
        [JsonPropertyName("list_name")] public string ListName { get; set; }
        [JsonPropertyName("amazon_product_url")]
        public string Url { get; set; }
        public string TypeMedia { get; set; }
        
        public override string ToString()
        {
            return "-" + Title.ToUpper() + " by " +
                   Author + " [" + Rank + " on NYT's Hardcover Fiction]\n" +
                   SummaryShort + "\n" + Url;
        }
    }
}

