﻿using System;
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

        public ProjectOption CreateProject(ProjectOption projectOption)
        {
            Project project = new Project
            {
                Id = projectOption.Id,
                Title = projectOption.Title,
                Description = projectOption.Description,
                Category = projectOption.Category,
                Update = projectOption.Update,
                Created = DateTime.UtcNow,
                Ammount = projectOption.Ammount
            };
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();
            return new ProjectOption
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Category = project.Category,
                Update = project.Update,
                Created = DateTime.UtcNow,
                Ammount = project.Ammount
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

        public List<ProjectOption> GetAllProjects()
        {
            using CFDBContext dbContext = new CFDBContext();
            List<Project> projects = dbContext.Projects.ToList();
            List<ProjectOption> projectsOpt = new List<ProjectOption>();
            projects.ForEach(project => projectsOpt.Add(new ProjectOption
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Category = project.Category,
                Update = project.Update,
                Ammount = project.Ammount
            }));

            return projectsOpt;
        }

        public List<ProjectOption> GetAllProjects(string searchCriteria)
        {

            List<Project> projects = dbContext.Projects.ToList();
            List<ProjectOption> projectsOpt = new List<ProjectOption>();
            projects.ForEach(project => projectsOpt.Add(new ProjectOption
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Category = project.Category,
                Update = project.Update,
                Ammount = project.Ammount
            })) ;

            return projectsOpt;
        }

        public ProjectOption GetProjectById(int id)
        {
            Project project = dbContext.Projects.Find(id);
            return new ProjectOption
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Category = project.Category,
                Update = project.Update,
                Created = DateTime.UtcNow,
                Ammount = project.Ammount
            };
        }

        public ProjectOption UpdateProject(ProjectOption projectOpt, int id)
        {
            Project project = dbContext.Projects.Find(id);
            projectOptToProject(projectOpt, project);
            dbContext.SaveChanges();
            return new ProjectOption
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Category = project.Category,
                Update = project.Update,
                Created = DateTime.UtcNow,
                Ammount = project.Ammount
            };

        }
        private static void projectOptToProject(ProjectOption projectOpt, Project project)

        {
            project.Id = projectOpt.Id;
            project.Title = projectOpt.Title;
            project.Description = projectOpt.Description;
            project.Category = projectOpt.Category;
            project.Update = projectOpt.Update;
            project.Created = DateTime.UtcNow;
            project.Ammount = projectOpt.Ammount;
        }
    }
}
