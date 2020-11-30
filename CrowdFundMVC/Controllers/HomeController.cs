using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    userId = "8"
                });
            }

            return Forbid();
        }



        //-----------------------------------------------------------------------------------
        public IActionResult Login_Form(int id)
        {

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

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
            try
            {
                ProjectwithFileModel projectOptions = projectService.GetProjectById(id);
                ProjectOptionModel model = new ProjectOptionModel { project = projectOptions };
                return View(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult UpdateUser()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult UpdatePackage()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult UpdateUserWithDetails([FromRoute] int id)
        {
            try
            {
                UserOption userOptions = userService.GetUserById(id);
                UserOptionModel model = new UserOptionModel { user = userOptions };
                return View(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult UpdatePackageWithDetails([FromRoute] int id)
        {
            try
            {
                PackageOption packageOptions = packageService.GetPackageById(id);
                PackageOptionModel model = new PackageOptionModel { package = packageOptions };

                return View(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult DeleteUserFromView([FromRoute] int id)
        {
            try
            {
                userService.DeleteUser(id);

                return Redirect("/Home/Users");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult DeletePackageFromView([FromRoute] int id)
        {
            try
            {
                packageService.DeletePackage(id);

                return Redirect("/Home/Packages");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult DeleteUser()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult DeletePackage()
        {
            try
            {
                List<ProjectwithFileModel> projects = projectService.GetAllProjects();
                ProjectModel projectModel = new ProjectModel { Projects = projects };
                return View(projectModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public IActionResult SearchProjectDisplay([FromQuery] string text)
        {
            try
            {
                List<ProjectwithFileModel> projects = projectService.GetAllProjects(text);
                ProjectModel projectModel = new ProjectModel { Projects = projects };
                return View("Projects", projectModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public IActionResult Category([FromQuery] int id)
        {
            try
            {
                List<ProjectwithFileModel> projects = projectService.SearchByCategory(id);
                ProjectModel projectModel = new ProjectModel { Projects = projects };
                return View("Projects", projectModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult AddProject()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult TopProjects()
        {
            try
            {
                List<ProjectwithFileModel> projects = projectService.GetTopProjects();
                ProjectModel projectModel = new ProjectModel { Projects = projects };
                return View("Projects", projectModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult MyProjects(int id)
        {
            try
            {
                List<ProjectwithFileModel> projects = projectService.GetMyProjects(id);
                ProjectModel projectModel = new ProjectModel { Projects = projects };
                return View("Projects", projectModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult DeleteProjectFromView([FromRoute] int id)
        {
            try
            {
                projectService.DeleteProject(id);

                return Redirect("/Home/Projects");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult UpdateProjectWithDetails([FromRoute] int id)
        {
            try
            {
                ProjectwithFileModel projectOptions = projectService.GetProjectById(id);
                ProjectOptionModel model = new ProjectOptionModel { project = projectOptions };

                return View(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IActionResult ProjectDetails([FromRoute] int id)
        {
            try
            {
                ProjectwithFileModel projectOptions = projectService.GetProjectById(id);
                IEnumerable<Package> projectPackages = projectService.GetProjectPackages(id);
                ProjectOptionModel model = new ProjectOptionModel { project = projectOptions, packages = projectPackages };

                return View(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult UpdateProject()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IActionResult DeleteProject()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult Dashboard()
        {
            try
            {
                List<ProjectwithFileModel> projects = projectService.GetTopProjects();
                ProjectModel projectModel = new ProjectModel { Projects = projects };
                return View(projectModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult Privacy()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult Users()
        {
            try
            {
                List<UserOption> users = userService.GetAllUsers();
                UserModel userModel = new UserModel { Users = users };
                return View(userModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult Packages()
        {
            try
            {
                List<PackageOption> packages = packageService.GetAllPackages();
                PackageModel packageModel = new PackageModel { Packages = packages };
                return View(packageModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult Projects()
        {
            try
            {
                List<ProjectwithFileModel> projects = projectService.GetAllProjects();
                ProjectModel projectModel = new ProjectModel { Projects = projects };
                return View(projectModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPut]
        public IActionResult FundProject([FromBody] FundingProject funding)
        {
            try
            {
                projectService.Funding(funding);
                return Ok();
            }
            catch (Exception e)

            {
                throw e;
            }
        }

        [HttpGet]
        public IActionResult MyFunds(int id)
        {
            try
            {
                List<ProjectwithFileModel> projects = projectService.GetMyProjects(id);
                ProjectModel projectModel = new ProjectModel { Projects = projects };
                return View("Projects", projectModel);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }

}