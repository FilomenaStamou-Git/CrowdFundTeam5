using System.Collections.Generic;
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
        List<ProjectwithFileModel> GetMyProjects(int id);
        ProjectwithFileModel GetProjectById(int id);
        IEnumerable<Package> GetProjectPackages(int id);
        void Funding(FundingProject funding);
        List<ProjectwithFileModel> SearchByCategory(int categoryId);
        List<ProjectwithFileModel> MyFundings(int id);      
    }
}
