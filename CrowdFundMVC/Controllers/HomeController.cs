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

        public IActionResult AddPackage()
        {
            return View();
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
            List<ProjectOption> projects = projectService.GetAllProjects();
            ProjectModel projectModel = new ProjectModel { Projects = projects };
            return View(projectModel);
        }

        public IActionResult AddProject()
        {
            return View();
        }

        public IActionResult DeleteProjectFromView([FromRoute] int id)
        {
            projectService.DeleteProject(id);

            return Redirect("/Home/Projects");
        }

        public IActionResult UpdateProjectWithDetails([FromRoute] int id)
        {
            ProjectOption projectOptions = projectService.GetProjectById(id);
            ProjectOptionModel model = new ProjectOptionModel { project = projectOptions };

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

        public IActionResult Dashboard()
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
