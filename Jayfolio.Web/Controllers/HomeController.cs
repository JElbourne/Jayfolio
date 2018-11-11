using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Jayfolio.Web.Models;
using Jayfolio.Web.Models.HomeViewModels;
using Jayfolio.Data;
using Jayfolio.Web.Models.PostViewModels;
using Jayfolio.Data.Models;
using Jayfolio.Web.Models.ProjectViewModels;

namespace Jayfolio.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost m_postService;

        public HomeController(IPost _postService)
        {
            m_postService = _postService;
        }

        public IActionResult Index()
        {
            var m_model = BuildHomeIndexModel();

            return View(m_model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var m_latestPosts = m_postService.GetLatestPosts(10);

            var m_posts = m_latestPosts.Select(post => new PostListingModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Project = GetProjectListingForPost(post)
            });

            return new HomeIndexModel
            {
                LatestPosts = m_posts,
                SearchQuery = ""
            };
        }

        private ProjectListingModel GetProjectListingForPost(Post post)
        {
            var m_project = post.Project;
            return new ProjectListingModel
            {
                Id = m_project.Id,
                Title = m_project.Title,
                ImageUrl = m_project.ImageUrl
            };
        }
    }
}
