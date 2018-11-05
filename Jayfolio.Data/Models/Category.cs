﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Jayfolio.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual IEnumerable<Project> Projects { get; set; }
    }
}
