using System.Collections.Generic;
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
