using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jayfolio.Web.Models.ProjectViewModels
{
    public class ProjectIndexModel
    {
        public IEnumerable<ProjectListingModel> ProjectList { get; set; }
    }
}
