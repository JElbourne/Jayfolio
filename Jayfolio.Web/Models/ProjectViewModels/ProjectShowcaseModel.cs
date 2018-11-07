using Jayfolio.Web.Models.PostViewModels;
using System.Collections.Generic;

namespace Jayfolio.Web.Models.ProjectViewModels
{
    public class ProjectShowcaseModel
    {
        public ProjectListingModel Project { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
    }
}
