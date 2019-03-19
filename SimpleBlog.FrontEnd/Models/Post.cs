using System;
using Newtonsoft.Json;

namespace SimpleBlog.FrontEnd.Models 
{
    public class Post 
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("backgroundColour")]
        public string BackgroundColour { get; set; }

        [JsonProperty("commentCount")]
        public int CommentCount { get; set; }

    }
}