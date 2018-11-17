using Jayfolio.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jayfolio.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(Project project, string searchQuery);
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        IEnumerable<Post> GetPostsByProjectId(int id);
        IEnumerable<Post> GetLatestPosts(int number);

        Task Add(Post newPost);
        Task Delete(int id);
        Task EditPostContent(int id, string newContent);

        Task AddReply(PostReply reply);
    }
}
