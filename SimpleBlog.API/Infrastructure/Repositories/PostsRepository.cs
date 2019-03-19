using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleBlog.API.Models;

namespace SimpleBlog.API.Infrastructure 
{
    public class PostsRepository : IPostsRepository 
    {
        public static IWebClient _client;

        public PostsRepository(IWebClient client)
        {
            _client = client;
        }

        public async Task<Post> Get(int id)
        {
            var json = await _client.GetData($"/{id}");
            return JsonConvert.DeserializeObject<Post>(json);
        }

        public async Task<IList<Post>> GetN(int count)
        {
            var posts = await GetAll();
            return posts.Take(count).ToList();
        }

        public async Task<IList<Post>> GetAll()
        {
            var json = await _client.GetData();
            List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(json);
            foreach(Post post in posts)
            {
                post.Slug = Helpers.UrlSlugger.ToUrlSlug(post.Title);
                post.BackgroundColour = Convert.ToString(post.Title.GetHashCode(), 16).Substring(0, 6);
            }

            return posts;
        }

        public async Task<Post> GetSlug(string slug)
        {
            var posts = await GetAll();
            foreach(Post post in posts)
            {
                post.Slug = Helpers.UrlSlugger.ToUrlSlug(post.Title);
                post.BackgroundColour = Convert.ToString(post.Title.GetHashCode(), 16).Substring(0, 6);
            }

            Post postResponse = posts.FirstOrDefault(p => p.Slug == slug);

            return postResponse;

        }
    }
}