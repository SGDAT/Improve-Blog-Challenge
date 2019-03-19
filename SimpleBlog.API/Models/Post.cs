using System;
using Newtonsoft.Json;

namespace SimpleBlog.API.Models 
{
    public class Post 
    {
        [JsonIgnore]
        public Guid Guid { 
            get { return System.Guid.NewGuid(); }
            set {} 
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("image")]
        public string Image => "https://via.placeholder.com/150x150";

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("backgroundColour")]
        public string BackgroundColour { get; set; }
    }
}