using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundCore.Options;
using CrowdFundCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFundMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;
        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
        [HttpGet]
        public List<ProjectOption> GetAllProjects()
        {
            return projectService.GetAllProjects();
        }

        [HttpPost]
        public ProjectOption AddProject(ProjectOption projectOpt)
        {
            ProjectOption projectOption = projectService.CreateProject(projectOpt);
            return projectOption;
        }

        [HttpPut("{id}")]
        public ProjectOption UpdateProject(ProjectOption projectOpt,int id)
        {
            return projectService.UpdateProject(projectOpt, id);

        }
        [HttpDelete("{id}")]
        public bool DeleteProject(int id)
        {
            return projectService.DeleteProject(id);
        }
    }
}
