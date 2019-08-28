using Siemens.MP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.MP.Entities
{
    public class Tasks
    {
        public Tasks(string taskName, string taskDescription, DateTime taskDeadline)
        {
            this.TaskName = taskName;
            this.TaskDescription = taskDescription;
            this.TaskDeadline = taskDeadline;
            this.TaskState = StateOfTask.TO_DO;
        }
        public int IdTask { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDeadline { get; set; }
        public StateOfTask TaskState { get; set; } 
    }
}
