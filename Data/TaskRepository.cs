using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = Siemens.MP.Entities.Task;

namespace Siemens.MP.Data
{
    public class TaskRepository : ITaskRepository, IDisposable
    {
        private ApplicationDbContext context;

        public TaskRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task<List<Task>> GetTasksAsync()
        {
            List<Task> colTasks = new List<Task>();
            using (var context = new ApplicationDbContext())
            {
                colTasks = (from tasks in context.Tasks   select tasks).ToList();
            }
            return System.Threading.Tasks.Task.FromResult(colTasks);
        }

        //public async System.Threading.Tasks.Task<List<Task>> GetTasksAsync()
        //{
        //    return await System.Threading.Tasks.Task.Run(() => context.Tasks.ToList());
        //}

        public Task GetTaskByID(int id)
        {
            return context.Tasks.Find(id);
        }

        public void InsertTask(Task task)
        {
            context.Tasks.Add(task);
            context.SaveChanges();
        }

        public void DeleteTask(int taskID)
        {
            Task task = context.Tasks.Find(taskID);
            context.Tasks.Remove(task);
        }

        public void UpdateTask(Task task)
        {
            context.Entry(task).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
