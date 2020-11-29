using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundCore.Models;
using CrowdFundCore.Options;

namespace CrowdFundCore.Services
{
    public interface IUserService
    {
        UserOption CreateUser(UserOption userOption);
        UserOption UpdateUser(UserOption userOption, int id);
        bool DeleteUser(int id);
        List<UserOption> GetAllUsers();
        UserOption GetUserById(int id);

    }
}
