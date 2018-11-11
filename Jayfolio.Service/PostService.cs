using Jayfolio.Data;
using Jayfolio.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayfolio.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext m_context;

        public PostService(ApplicationDbContext _context)
        {
            m_context = _context;
        }

        public async Task Add(Post newPost)
        {
            m_context.Add(newPost);
            await m_context.SaveChangesAsync();
        }

        public Task AddReply(PostReply reply)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            return m_context.Posts.Where(post => post.Id == id)
                .Include(post => post.User)
                .Include(post => post.Replies).ThenInclude(reply => reply.User)
                .Include(post => post.Project)
                .First();
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetLatestPosts(int number)
        {
            return GetAll().OrderByDescending(post => post.Created).Take(number);
        }

        public IEnumerable<Post> GetPostsByProjectId(int id)
        {
            return m_context.Projects
                .Where(project => project.Id == id)
                .First()
                .Posts;
        }
    }
}
