using Jayfolio.Web.Models.ProjectViewModels;
using System;

namespace Jayfolio.Web.Models.PostViewModels
{
    public class PostListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string MediaUrl { get; set; }
        public string DatePosted { get; set; }

        public string AuthorId { get; set; }
        public string AuthorName { get; set; }

        public ProjectListingModel Project { get; set; }

        public int RepliesCount { get; set; }

    }
}
