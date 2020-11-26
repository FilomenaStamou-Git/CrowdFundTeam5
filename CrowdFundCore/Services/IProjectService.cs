using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundCore.Models;
using CrowdFundCore.Options;

namespace CrowdFundCore.Services
{
    public interface IProjectService
    {
        ProjectwithFileModel CreateProject(ProjectwithFileModel projectOption);
        ProjectwithFileModel UpdateProject(ProjectwithFileModel projectOption, int id);
        bool DeleteProject(int id);
        List<ProjectwithFileModel> GetAllProjects();
        List<ProjectwithFileModel> GetAllProjects(string searchCriteria);
        List<ProjectwithFileModel> GetTopProjects();
        ProjectwithFileModel GetProjectById(int id);

    }
}
