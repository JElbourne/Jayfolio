using System;
using System.Collections.Generic;
using System.Text;

namespace Jayfolio.Data.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<Project> Projects { get; set; }
    }
}
