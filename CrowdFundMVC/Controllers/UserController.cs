using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrowdFundCore.Options;
using CrowdFundCore.Services;
using CrowdFundCore.Models;

namespace CrowdFundMVC.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            private readonly IUserService userService;
            public UserController(IUserService userService)
            {
                this.userService = userService;
            }
            [HttpPost]
            public UserOption AddUser(UserOption userOpt)
            {
                UserOption userOption = userService.CreateUser(userOpt);
                return userOption;
            }
    }
}
