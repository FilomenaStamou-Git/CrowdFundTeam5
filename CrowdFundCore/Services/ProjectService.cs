using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundCore.Data;
using CrowdFundCore.Models;
using CrowdFundCore.Options;

namespace CrowdFundCore.Services
{
    public class ProjectService : IProjectService
    {

        private readonly CFDBContext dbContext;

        public ProjectService(CFDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        
        public ProjectwithFileModel CreateProject(ProjectwithFileModel projectOption)
        {

            Project project = new Project
            {
                Id = projectOption.Id,
                Title = projectOption.Title,
                Description = projectOption.Description,
                Categories = projectOption.Categories,
                Update = projectOption.Update,
                Created = DateTime.UtcNow,
                Amount = projectOption.Amount,
                Photo = projectOption.Photo,
                Video = projectOption.Video,
                Fundings = 0,
                UserId = projectOption.UserId
            };
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();


            return new ProjectwithFileModel
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Categories = project.Categories,
                Update = project.Update,
                Created = DateTime.UtcNow,
                Amount = project.Amount,
                Photo = project.Photo,
                Video = project.Video,
                Fundings = project.Fundings,
                UserId = project.UserId
            };
        }

        public bool DeleteProject(int id)
        {
            Project project = dbContext.Projects.Find(id);
            if (project == null) return false;
            dbContext.Projects.Remove(project);
            dbContext.SaveChanges();
            return true;
        }

        public List<ProjectwithFileModel> GetAllProjects()
        {
            using CFDBContext dbContext = new CFDBContext();
            List<Project> projects = dbContext.Projects.ToList();
            List<ProjectwithFileModel> projectsOpt = new List<ProjectwithFileModel>();
            projects.ForEach(project => projectsOpt.Add(new ProjectwithFileModel
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Categories = project.Categories,
                Update = project.Update,
                Amount = project.Amount,
                Fundings = project.Fundings,
                Photo = project.Photo,
                Video = project.Video
            }));

            return projectsOpt;
        }

        public List<ProjectwithFileModel> GetAllProjects(string searchCriteria)
        {

            List<Project> projects = dbContext.Projects
                .Where(p => p.Title.Contains(searchCriteria) || Enum.IsDefined(typeof(Category),searchCriteria))
                .ToList();

           List <ProjectwithFileModel> projectsOpt = new List<ProjectwithFileModel>();
            projects.ForEach(project => projectsOpt.Add(new ProjectwithFileModel
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Categories = project.Categories,
                Update = project.Update,
                Amount = project.Amount,
                Fundings = project.Fundings,
                Photo = project.Photo,
                Video = project.Video
            })) ;

            return projectsOpt;
        }

        public ProjectwithFileModel GetProjectById(int id)
        {
            Project project = dbContext.Projects.Find(id);
            return new ProjectwithFileModel
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Categories = project.Categories,
                Update = project.Update,
                Created = DateTime.UtcNow,
                Fundings = project.Fundings,
                Amount = project.Amount,
                Photo = project.Photo,
                Video = project.Video
            };
        }

        public IEnumerable<Package> GetProjectPackages(int id)
        {
            IEnumerable<Package> packages = dbContext.Packages.Where(p => p.ProjectId == id).ToList();
            return packages;
        }


        public ProjectwithFileModel UpdateProject(ProjectwithFileModel projectOpt, int id)
        {
            Project project = dbContext.Projects.Find(id);
            projectOptToProject(projectOpt, project);
            dbContext.SaveChanges();
            return new ProjectwithFileModel
            {
                Title = project.Title,
                Description = project.Description,
                Categories = project.Categories,
                Update = project.Update,
                Fundings =project.Fundings,
                Created = DateTime.UtcNow,
                Amount = project.Amount,
                Photo = project.Photo,
                Video = project.Video
            };

        }
        private static void projectOptToProject(ProjectwithFileModel projectOpt, Project project)

        {
            project.Id = projectOpt.Id;
            project.Title = projectOpt.Title;
            project.Description = projectOpt.Description;
            project.Categories = projectOpt.Categories;
            project.Update = projectOpt.Update;
            project.Created = DateTime.UtcNow;
            project.Fundings = projectOpt.Fundings;
            project.Amount = projectOpt.Amount;
            project.Photo = projectOpt.Photo;
            project.Video = projectOpt.Video;
        }

        public List<ProjectwithFileModel> GetTopProjects()
        {
            List<Project> projects = dbContext.Projects
                .Take(5)
                .OrderByDescending(p =>p.Fundings)
                .ThenBy(p=>p.Title)                
                .ToList();
            List<ProjectwithFileModel> projectsOpt = new List<ProjectwithFileModel>();
            projects.ForEach(project => projectsOpt.Add(new ProjectwithFileModel
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Categories = project.Categories,
                Update = project.Update,
                Amount = project.Amount,
                Fundings = project.Fundings,
                Photo = project.Photo,
                Video = project.Video
            }));
            return projectsOpt;

        }


        public void Funding (FundingProject funding)
        {
            User user = dbContext.Users.Find(funding.userid);
           // user.Gross = +funding.reward;
            Project project = dbContext.Projects.Find(funding.projectid);
            project.Fundings = +funding.reward;

            Package package = dbContext.Packages.Find(funding.packageid);
        }



    }
}
