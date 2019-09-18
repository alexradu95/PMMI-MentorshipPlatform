using Siemens.MP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.MP.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptionPreview { get; set; }
        public DateTime Deadline { get; set; }
        public StateOfTask State { get; set; }
        public int IdAsignee { get; set; }
        public int IdReporter { get; set; }
        public Priority PriorityState { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
