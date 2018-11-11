using Jayfolio.Web.Models.PostViewModels;
using System.Collections.Generic;

namespace Jayfolio.Web.Models.HomeViewModels
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<PostListingModel> LatestPosts { get; set; }
    }
}
