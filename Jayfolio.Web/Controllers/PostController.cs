using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jayfolio.Data;
using Jayfolio.Data.Models;
using Jayfolio.Web.Models.PostViewModels;
using Jayfolio.Web.Models.ReplyViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Jayfolio.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost m_postService;
        public PostController(IPost _postService)
        {
            m_postService = _postService;
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