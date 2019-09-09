using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = Siemens.MP.Entities.Task;

namespace Siemens.MP.Data
{
    public interface ITaskRepository : IDisposable
    {
        System.Threading.Tasks.Task<List<Task>> GetTasksAsync();
        Task GetTaskByID(int taskID);
        void InsertTask(Task task);
        void DeleteTask(int taskID);
        void UpdateTask(Task task);
        void Save();
    }
}
