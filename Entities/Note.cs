using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.MP.Entities
{
    public class Note : AbstractEntity
    {
        public Note(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
        public Note()
        {
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
