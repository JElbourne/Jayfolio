using System;
using System.Collections.Generic;
using System.Text;

namespace Jayfolio.Data.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public virtual Status Status { get; set; }
        public virtual Category Category { get; set; }
        public virtual IEnumerable<Post> Posts { get; set; }
        public virtual IEnumerable<ProjectSkill> ProjectSkills { get; } = new List<ProjectSkill>();
    }
}
