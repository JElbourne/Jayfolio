using Jayfolio.Data;
using Jayfolio.Data.Models;
using Jayfolio.Web.Models.PostViewModels;
using Jayfolio.Web.Models.ProjectViewModels;
using Jayfolio.Web.Models.SearchViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Jayfolio.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPost m_postService;

        public SearchController(IPost _postService)
        {
            m_postService = _postService;
        }

        public IActionResult Results(string searchQuery)
        {
            var m_posts = m_postService.GetFilteredPosts(searchQuery);

            var m_noResults = (!string.IsNullOrEmpty(searchQuery) && !m_posts.Any());

            var m_postListings = m_posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Project = BuildProjectListing(post)
            });

            var m_model = new SearchResultModel
            {
                Posts = m_postListings,
                SearchQuery = searchQuery,
                EmptyStringResults = m_noResults
            };

            return View(m_model);
        }

        private ProjectListingModel BuildProjectListing(Post post)
        {
            var project = post.Project;

            return new ProjectListingModel
            {
                Id = project.Id,
                ImageUrl = project.ImageUrl,
                Title = project.Title,
                Description = project.Description
            };
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Results", new { searchQuery });
        }
    }
}