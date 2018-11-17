using System;
using System.Collections.Generic;
using System.Linq;
using Jayfolio.Data;
using Jayfolio.Data.Models;
using Jayfolio.Web.Models.PostViewModels;
using Jayfolio.Web.Models.ProjectViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Jayfolio.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProject m_projectService;
        private readonly IPost m_postService;

        public ProjectController(IProject _projectService, IPost _postService)
        {
            m_projectService = _projectService;
            m_postService = _postService;
        }

        public IActionResult Index()
        {
            var m_projects = m_projectService.GetAll()
                .Select(project => new ProjectListingModel
                {
                    Id = project.Id,
                    Title = project.Title,
                    Description = project.Description
                });

            var m_model = new ProjectIndexModel
            {
                ProjectList = m_projects
            };

            return View(m_model);
        }

        public IActionResult Showcase(int id, string searchQuery)
        {
            var m_project = m_projectService.GetById(id);
            var m_posts = m_postService.GetFilteredPosts(m_project, searchQuery).ToList();

            var m_postListings = m_posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                Title = post.Title,
                Content = post.Content,
                MediaUrl = post.MediaUrl,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Project = BuildProjectListing(post)
            });

            var m_model = new ProjectShowcaseModel
            {
                Posts = m_postListings,
                Project = BuildProjectListing(m_project)
            };

            return View(m_model);
        }

        [HttpPost]
        public IActionResult Search(int id, string searchQuery)
        {
            return RedirectToAction("ShowCase", new { id, searchQuery });
        }

        private ProjectListingModel BuildProjectListing(Post _post)
        {
            var m_project = _post.Project;
            return BuildProjectListing(m_project);

        }

        private ProjectListingModel BuildProjectListing(Project _project)
        {
            return new ProjectListingModel
            {
                Id = _project.Id,
                Title = _project.Title,
                Description = _project.Description,
                ImageUrl = _project.ImageUrl
            };
        }
    }
}