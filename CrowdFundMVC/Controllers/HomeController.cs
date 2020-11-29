using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundCore.Models;
using CrowdFundCore.Options;
using CrowdFundCore.Services;
using CrowdFundCoreServices;
using CrowdFundMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrowdFundMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;
        private readonly IProjectService projectService;
        private readonly IPackageService packageService;

        public HomeController(ILogger<HomeController> logger, IUserService _userService, IProjectService _projectService, IPackageService _packageService)
        {
            _logger = logger;
            userService = _userService;
            projectService = _projectService;
            packageService = _packageService;
        }
//---------------LOGIN--------------------------------------------------------------
        [HttpPost]
        public IActionResult Login([FromBody] LoginOptions options)
        {
 

            if (options.Email == "fundastic@gmail.com")
            {
                return Ok(new
                {
                    userId = "40"
                });
            }

            return Forbid();
        }

        public IActionResult Login_Form(int id)
        {

            return View();
        }

        //-----------------------------------------------------------------------------------

        
        //----------------------------------INDEX-------------------------------------------------
        public IActionResult Index()
        {
            List<ProjectwithFileModel> projects = projectService.GetAllProjects();
            ProjectModel projectModel = new ProjectModel { Projects = projects };
            return View(projectModel);
        }
        //-----------------------------------------------------------------------------------

        //--------------------------------DASHBOARD-------------------------------------------
        public IActionResult Dashboard()
        {
            List<ProjectwithFileModel> projects = projectService.GetTopProjects();
            ProjectModel projectModel = new ProjectModel { Projects = projects };
            return View(projectModel);
        }

        //-----------------------------------------------------------------------------------
        public IActionResult About()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddPackage([FromRoute] int id)
        {
            ProjectwithFileModel projectOptions = projectService.GetProjectById(id);
            ProjectOptionModel model = new ProjectOptionModel { project = projectOptions };

            return View(model);
        }

        public IActionResult UpdateUser()
        {
            return View();
        }

        public IActionResult UpdatePackage()
        {
            return View();
        }

        public IActionResult UpdateUserWithDetails([FromRoute] int id)
        {
            UserOption userOptions = userService.GetUserById(id);
            UserOptionModel model = new UserOptionModel { user = userOptions };

            return View(model);
        }

        public IActionResult UpdatePackageWithDetails([FromRoute] int id)
        {
            PackageOption packageOptions = packageService.GetPackageById(id);
            PackageOptionModel model = new PackageOptionModel { package = packageOptions };

            return View(model);
        }

        public IActionResult DeleteUserFromView([FromRoute] int id)
        {
            userService.DeleteUser(id);

            return Redirect("/Home/Users");
        }

        public IActionResult DeletePackageFromView([FromRoute] int id)
        {
            packageService.DeletePackage(id);

            return Redirect("/Home/Packages");
        }

        public IActionResult DeleteUser()
        {
            return View();
        }

        public IActionResult DeletePackage()
        {
            List<ProjectwithFileModel> projects = projectService.GetAllProjects();
            ProjectModel projectModel = new ProjectModel { Projects = projects };
            return View(projectModel);
        }



        public IActionResult SearchProjectDisplay([FromQuery] string text)
        {
            List<ProjectwithFileModel> projects = projectService.GetAllProjects(text);
            ProjectModel projectModel = new ProjectModel { Projects = projects };
            return View("Projects", projectModel);
        }

        public IActionResult AddProject()
        {
            return View();
        }

        public IActionResult TopProjects()
        {
            List<ProjectwithFileModel> projects = projectService.GetTopProjects();
            ProjectModel projectModel = new ProjectModel { Projects = projects };
            return View("Projects", projectModel);
        }

        public IActionResult MyProjects(int id)
        {
            List<ProjectwithFileModel> projects = projectService.GetMyProjects(id);
            ProjectModel projectModel = new ProjectModel { Projects = projects };
            return View("Projects", projectModel);
        }

        public IActionResult DeleteProjectFromView([FromRoute] int id)
        {
            projectService.DeleteProject(id);

            return Redirect("/Home/Projects");
        }

        public IActionResult UpdateProjectWithDetails([FromRoute] int id)
        {
            ProjectwithFileModel projectOptions = projectService.GetProjectById(id);
            ProjectOptionModel model = new ProjectOptionModel { project = projectOptions };

            return View(model);
        }
        public IActionResult ProjectDetails([FromRoute] int id)
        {
            ProjectwithFileModel projectOptions = projectService.GetProjectById(id);
            IEnumerable<Package> projectPackages = projectService.GetProjectPackages(id);
            ProjectOptionModel model = new ProjectOptionModel { project = projectOptions ,packages = projectPackages};

            return View(model);
        }

        public IActionResult UpdateProject()
        {
            return View();
        }
        public IActionResult DeleteProject()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Users()
        {
            List<UserOption> users = userService.GetAllUsers();
            UserModel userModel = new UserModel { Users = users };
            return View(userModel);
        }

        public IActionResult Packages()
        {
            List<PackageOption> packages = packageService.GetAllPackages();
            PackageModel packageModel = new PackageModel { Packages = packages };
            return View(packageModel);
        }

        public IActionResult Projects()
        {
            List<ProjectwithFileModel> projects = projectService.GetAllProjects();
            ProjectModel projectModel = new ProjectModel { Projects = projects };
            return View(projectModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPut]
        public IActionResult FundProject([FromBody] FundingProject funding)
        {      
            projectService.Funding(funding);
            return Ok();
        }

    }

}
