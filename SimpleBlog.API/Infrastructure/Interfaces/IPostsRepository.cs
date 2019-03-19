using SimpleBlog.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlog.API.Infrastructure 
{
    public interface IPostsRepository 
    {
        Task<IList<Post>> GetAll();
        Task<IList<Post>> GetN(int count);
        Task<Post> Get(int id);
        Task<Post> GetSlug(string slug);
    }
}