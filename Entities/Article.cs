using Microsoft.AspNetCore.Identity;
using Siemens.MP.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.MP.Entities
{
    public class Article : AbstractEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Categories ArticleCategory { get; set; }

    }
}
