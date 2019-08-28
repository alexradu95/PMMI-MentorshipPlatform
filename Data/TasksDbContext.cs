using Microsoft.EntityFrameworkCore;
using Siemens.MP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.MP.Data
{
    public class TasksDbContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }

        public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
