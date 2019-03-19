using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleBlog.API.Infrastructure;
using SimpleBlog.API.Models;

namespace SimpleBlog.API.Controllers 
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase 
    {
        public readonly IPostsRepository _postsRepo;
        public PostsController(IPostsRepository postsRepo) {
            _postsRepo = postsRepo;
        }

        // api/posts
        [HttpGet]
        public async Task<ActionResult<string>> Get() 
        {
            return JsonConvert.SerializeObject(await _postsRepo.GetN(100));
        }

        // api/posts/1
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id) 
        {
            return JsonConvert.SerializeObject(await _postsRepo.Get(id));
        }

        // api/posts/post-title
        [HttpGet("s/{slug}")]
        public async Task<ActionResult<string>> Get(string slug)
        {
            return JsonConvert.SerializeObject(await _postsRepo.GetSlug(slug));
        }
    }
}