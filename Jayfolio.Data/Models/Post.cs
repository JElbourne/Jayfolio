﻿using System;
using System.Collections.Generic;

namespace Jayfolio.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string MediaUrl { get; set; }
        public DateTime Created { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Project Project { get; set; }

        public virtual IEnumerable<PostReply> Replies { get; set; }
    }
}
