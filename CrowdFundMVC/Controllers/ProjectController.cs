using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundCore.Options;
using CrowdFundCore.Services;
using CrowdFundMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFundMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;
        private readonly IWebHostEnvironment hostingEnvironment;


        public ProjectController(IProjectService projectService, IWebHostEnvironment environment)
        {
            this.projectService = projectService;
            hostingEnvironment = environment;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        [HttpPost]
        public ProjectOption AddProject([FromForm] ProjectWithFileModel projectOptWithFileModel)
        {

            if (projectOptWithFileModel == null) return null;
            var formFile = projectOptWithFileModel.Picture;

            var filename = projectOptWithFileModel.Picture.FileName;

            if (formFile.Length > 0)
            {

                var filePath = Path.Combine(hostingEnvironment.WebRootPath, "uploadedimages", filename);


                using (var stream = System.IO.File.Create(filePath))
                {
                    formFile.CopyTo(stream);
                }
            }

            ProjectOption projectOpt = new ProjectOption
            {
                Id = projectOptWithFileModel.Id,
                Title = projectOptWithFileModel.Title,
                Description = projectOptWithFileModel.Description,
                Category = projectOptWithFileModel.Category,
                Update = projectOptWithFileModel.Update,
                Photo = projectOptWithFileModel.Photo,
                Video = projectOptWithFileModel.Video,
                Amount = projectOptWithFileModel.Amount,
                Fundings = projectOptWithFileModel.Fundings
            };

            projectOpt.Photo = filename;

            ProjectOption projectOption = projectService.CreateProject(projectOpt);
            return projectOption;
        }


        [HttpGet]
        public List<ProjectOption> GetAllProjects()
        {
            return projectService.GetAllProjects();
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
