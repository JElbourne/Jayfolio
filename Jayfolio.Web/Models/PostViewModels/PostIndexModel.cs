﻿using Jayfolio.Web.Models.ReplyViewModel;
using System;
using System.Collections.Generic;

namespace Jayfolio.Web.Models.PostViewModels
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MediaCaption { get; set; }
        public string MediaUrl { get; set; }
        public DateTime Created { get; set; }

        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }

        public IEnumerable<PostReplyModel> Replies { get; set; }

    }
}
