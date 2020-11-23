using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundCore.Models;
using CrowdFundCore.Options;
using CrowdFundCore.Data;

namespace CrowdFundCore.Services
{
    public class UserService : IUserService
    {
        private readonly CFDBContext dbContext;

        public UserService(CFDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<UserOption> GetAllUsers()
        {
            List<User> users = dbContext.Users.ToList();
            List<UserOption> usersOpt = new List<UserOption>();
            users.ForEach(user => usersOpt.Add(new UserOption
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Id = user.Id
            }));

            return usersOpt;
        }

        public UserOption CreateUser(UserOption userOption)
        {
            User user = new User
            {
                FirstName = userOption.FirstName,
                LastName = userOption.LastName,
                Email = userOption.Email,
                Password = userOption.Password
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return new UserOption
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };
        }

        public bool DeleteUser(int id)
        {
            User user = dbContext.Users.Find(id);
            if (user == null) return false;
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return true;
        }

        public UserOption UpdateUser(UserOption userOpt, int id)
        {
            User user = dbContext.Users.Find(id);
            userOptToUser(userOpt, user);
            dbContext.SaveChanges();

            return new UserOption
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };
        }

        public UserOption GetUserById(string email)
        {
            User user= dbContext.Users.Find(email);
            return new UserOption
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Id = user.Id 
            };
        }
        private static void userOptToUser(UserOption userOpt, User user)
        {
            user.FirstName = userOpt.FirstName;
            user.LastName = userOpt.LastName;
            user.Email = userOpt.Email;
            user.Password = userOpt.Password;
        }

    }
}
