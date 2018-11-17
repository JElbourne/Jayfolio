using Jayfolio.Web.Models.PostViewModels;
using System.Collections.Generic;

namespace Jayfolio.Web.Models.SearchViewModels
{
    public class SearchResultModel
    {
        public IEnumerable<PostListingModel> Posts { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptyStringResults { get; set; }
    }
}
