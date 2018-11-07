using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jayfolio.Web.Models.ProjectViewModels
{
    public class ProjectListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
