using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.MP.Entities
{
    public class Project
    {
        public Project(string title, string description)
        {
            this.Title = title;
            this.Description = description;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
