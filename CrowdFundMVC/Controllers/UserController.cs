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
        [HttpGet]
        public List<UserOption> GetAllUsers()
        {
            return userService.GetAllUsers();
        }

        [HttpPost]
            public UserOption AddUser(UserOption userOpt)
            {
                UserOption userOption = userService.CreateUser(userOpt);
                return userOption;
            }

        [HttpPut("{email}")]
        public UserOption UpdateUser(int id, UserOption userOpt)
        {
            return userService.UpdateUser(userOpt, id);

        }
        [HttpDelete("{email}")]
        public bool DeleteUser(string email)
        {
            return userService.DeleteUser(email);
        }
    }
}
