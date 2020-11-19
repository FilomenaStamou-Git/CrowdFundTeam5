﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundCore.Models;
using CrowdFundCore.Options;

namespace CrowdFundCore.Services
{
    public interface IProjectService
    {
        ProjectOption CreateProject(ProjectOption projectOption);
        ProjectOption UpdateProject(ProjectOption projectOption, int id);
        bool DeleteProject(int id);
        List<ProjectOption> FindAllProjects();
        List<ProjectOption> FindAllProjects(string searchCriteria); 
    }
}