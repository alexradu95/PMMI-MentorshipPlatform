﻿using Siemens.MP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.MP.Data
{
        public interface IProjectRepository : IDisposable
        {
            System.Threading.Tasks.Task<List<Project>> GetProjectsAsync();
            Project GetProjectByID(int projectID);
            void InsertProject(Project project);
            void DeleteProject(int projectID);
            void UpdateProject(Project project);
            void Save();
        }
}
