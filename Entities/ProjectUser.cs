using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.MP.Entities
{
    public class ProjectUser : AbstractEntity
    {
        public int Id { get; set; }
        public string UserInfoId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
