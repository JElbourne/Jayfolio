using System;
using System.Collections.Generic;
using System.Text;

namespace Jayfolio.Data.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<ProjectSkill> ProjectSkills { get; } = new List<ProjectSkill>();
    }
}
