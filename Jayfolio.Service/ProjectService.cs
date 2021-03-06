﻿using Jayfolio.Data;
using Jayfolio.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jayfolio.Service
{
    public class ProjectService : IProject
    {
        private readonly ApplicationDbContext m_context;

        public ProjectService(ApplicationDbContext _context)
        {
            m_context = _context;
        }

        public Task Create(Project _project)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int _projectId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAll()
        {
            return m_context.Projects
                .Include(project => project.Posts);
        }

        public Project GetById(int _id)
        {
            var project = m_context.Projects.Where(p => p.Id == _id)
                .Include(p => p.Posts).ThenInclude(pt => pt.User)
                .Include(p => p.Posts).ThenInclude(pt => pt.Replies).ThenInclude(r => r.User)
                .FirstOrDefault();

            return project;
        }

        public Task UpdateProjectDescription(int _porjectId, string _newDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProjectTitle(int _projectId, string _newTitle)
        {
            throw new NotImplementedException();
        }
    }
}
