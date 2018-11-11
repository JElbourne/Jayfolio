using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jayfolio.Data;
using Jayfolio.Data.Models;
using Jayfolio.Web.Models.PostViewModels;
using Jayfolio.Web.Models.ReplyViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jayfolio.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost m_postService;
        private readonly IProject m_projectService;

        private static UserManager<ApplicationUser> m_userManager;

        public PostController(IPost _postService, IProject _projectService, UserManager<ApplicationUser> _userManager)
        {
            m_postService = _postService;
            m_projectService = _projectService;
            m_userManager = _userManager;
        }

        public IActionResult Index(int id)
        {
            var m_post = m_postService.GetById(id);

            var m_replies = BuildPostReplies(m_post.Replies);

            var m_model = new PostIndexModel
            {
                Id = m_post.Id,
                Title = m_post.Title,
                AuthorId = m_post.User.Id,
                AuthorName = m_post.User.UserName,
                AuthorImageUrl = m_post.User.ProfileImageUrl,
                Created = m_post.Created,
                MediaCaption = m_post.Content,
                Replies = m_replies
            };

            return View(m_model);
        }

        public IActionResult Create(int id)
        {
            // Note: id is Project.Id
            var m_project = m_projectService.GetById(id);

            var m_model = new NewPostModel
            {
                ProjectId = m_project.Id,
                ProjectName = m_project.Title,
                ProjectImageUrl =m_project.ImageUrl,
                AuthorName = User.Identity.Name
            };

            return View(m_model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var m_userId = m_userManager.GetUserId(User);
            var m_user = m_userManager.FindByIdAsync(m_userId).Result;

            var m_post = BuildPost(model, m_user);

            // m_postService.Add(m_post).Wait(); // Block the current thread until the tast is complete
            await m_postService.Add(m_post);

            return RedirectToAction("Index", "Post", new { id = m_post.Id } );
        }

        private Post BuildPost(NewPostModel _model, ApplicationUser _user)
        {
            var m_project = m_projectService.GetById(_model.ProjectId);

            return new Post
            {
                Title = _model.Title,
                Content = _model.Content,
                Created = DateTime.Now,
                User = _user,
                Project = m_project
            };
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                AuthorId = reply.User.Id,
                AuthorName = reply.User.UserName,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                Created = reply.Created,
                ReplyContent = reply.Content
            });
        }
    }
}