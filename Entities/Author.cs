using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.MP.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Article> Articles { get; set; } 
    }
}
