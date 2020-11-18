using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectCF.Models;
using ProjectCF.Options;

namespace ProjectCF.Services
{
    interface IUserService
    {
        UserOption CreateUser(UserOption userOption);
        UserOption UpdateUser(UserOption userOption, string email);
        UserOption DeleteUser(UserOption userOption, string email);
    }
}
