using Microsoft.EntityFrameworkCore;
using Siemens.MP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.MP.Data
{
    public class ProjectRepository : IProjectRepository, IDisposable
    {
        private ApplicationDbContext context;

        public ProjectRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task<List<Project>> GetProjectsAsync()
        {
            List<Project> colProjects = new List<Project>();
            using (var context = new ApplicationDbContext())
            {
                colProjects = (from projects in context.Projects select projects).ToList();
            }
            return System.Threading.Tasks.Task.FromResult(colProjects);
        }

        //public async System.Threading.Tasks.Task<List<Task>> GetTasksAsync()
        //{
        //    return await System.Threading.Tasks.Task.Run(() => context.Tasks.ToList());
        //}

        public Project GetProjectByID(int id)
        {
            return context.Projects.Find(id);
        }

        public void InsertProject(Project project)
        {
            context.Projects.Add(project);
            Save();
        }

        public void DeleteProject(int projectID)
        {
            Project project = context.Projects.Find(projectID);

            context.Projects.Remove(project);
        }

        public void UpdateProject(Project project)
        {
            context.Entry(project).State = EntityState.Modified;
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
