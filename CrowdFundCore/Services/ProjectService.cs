﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundCore.Models;
using CrowdFundCore.Options;

namespace CrowdFundCore.Services
{
    public class ProjectService : IProjectService
    {
        public ProjectOption CreateProject(ProjectOption projectOption)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProjectOption> FindAllProjects()
        {
            throw new NotImplementedException();
        }

        public List<ProjectOption> FindAllProjects(string searchCriteria)
        {
            throw new NotImplementedException();
        }

        public ProjectOption UpdateProject(ProjectOption projectOption, int id)
        {
            throw new NotImplementedException();
        }
    }
}