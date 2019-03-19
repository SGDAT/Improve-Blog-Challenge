using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.FrontEnd.Infrastructure;
using SimpleBlog.FrontEnd.Models;
using SimpleBlog.FrontEnd.ViewModels;

namespace SimpleBlog.FrontEnd.Controllers
{
    public class PostsController : Controller
    {

        protected readonly IPostsRepository postsRepo;
        protected readonly ICommentsRepository commentsRepo;

        public PostsController(IPostsRepository postsRepo, ICommentsRepository commentsRepo) 
        {
            this.postsRepo = postsRepo;
            this.commentsRepo = commentsRepo;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await postsRepo.GetAll<Post>();
            var vm = new PostsViewModel 
            {
                Posts = posts.ToList()
            };
            return View(vm);
        }

        [Route("/posts/details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var post = await postsRepo.Get<Post>(id);
            var comments = await commentsRepo.GetAll<Comment>(id);
            var vm = new PostDetailsViewModel 
            {
                Post = post,
                Comments = comments.ToList(),
            };
            return View(vm);
        }

        [Route("/posts/{slug}")]
        public async Task<IActionResult> DetailsSlug(string slug)
        {
            var post = await postsRepo.Get<Post>(slug);
            var comments = await commentsRepo.GetAll<Comment>(post.Id);
            var vm = new PostDetailsViewModel
            {
                Post = post,
                Comments = comments.ToList(),
            };
            return View(nameof(Details), vm);
        }
    }
}
