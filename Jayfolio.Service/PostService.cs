﻿using Jayfolio.Data;
using Jayfolio.Data.Models;
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

        public Task Add(Post newPost)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
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
