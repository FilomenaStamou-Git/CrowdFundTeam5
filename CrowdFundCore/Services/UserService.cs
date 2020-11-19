using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundCore.Models;
using CrowdFundCore.Options;
using ProjectCF_Console.Data;

namespace CrowdFundCore.Services
{
    public class UserService : IUserService
    {
        private readonly CFDBContext dbContext;

        public UserService(CFDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public UserOption CreateUser(UserOption userOption)
            {
            //validation
            if (userOption == null) return null;
            if (userOption.FirstName == null) return null;

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

        public bool DeleteUser(string email)
        {
            User user = dbContext.Users.Find(email);
            if (user == null) return false;
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return true;
            
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
                Password = user.Password,
                Id = user.Id
            }));

            return usersOpt;
        }

        public UserOption GetUserById(int id)
        {
            User user = dbContext.Users.Find(id);
                if (user == null) return null;          
                return new UserOption
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,                   
                };
            
        }

        public UserOption UpdateUser(UserOption userOption, string email)
        {
            User user = dbContext.Users.Find(email);
            //userOptionToUser(userOption, user);
            dbContext.SaveChanges();
            return new UserOption
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };
        }
        

    }
}
