using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundCore.Models;
using CrowdFundCore.Options;
using CrowdFundCore.Services;
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

        public HomeController(ILogger<HomeController> logger, IUserService _userService, IProjectService _projectService)
        {
            _logger = logger;
            userService = _userService;
            projectService = _projectService;
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


        public IActionResult UpdateUser()
        {
            return View();
        }

        public IActionResult UpdateUserWithDetails([FromRoute] int id)
        {
            UserOption userOptions = userService.GetUserById(id);
            UserOptionModel model = new UserOptionModel { user = userOptions };

            return View(model);
        }

        public IActionResult DeleteUserFromView([FromRoute] int id)
        {
            userService.DeleteUser(id);

            return Redirect("/Home/Users");
        }

        public IActionResult DeleteUser()
        {
            return View();
        }

        public IActionResult Projects()
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
            UserModel userModel = new UserModel { Users = users};
            return View(userModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
