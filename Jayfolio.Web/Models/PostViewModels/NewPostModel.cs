using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jayfolio.Web.Models.PostViewModels
{
    public class NewPostModel
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectImageUrl { get; set; }
        public string AuthorName { get; set; }
    }
}
