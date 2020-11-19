using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectCF.Models;
using ProjectCF.Options;
using ProjectCF_Console.Data;

namespace ProjectCF.Services
{
    public class UserService : IUserService
    {
        private readonly CFDBContext dbContext = new CFDBContext();

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
                    Email = userOption.Email
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

        public UserOption DeleteUser(UserOption userOption, string email)
        {
            User user = dbContext.Users.Find(email);
            if (user == null) return false;
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return true;
            
        }

        public UserOption UpdateUser(UserOption userOption, string email)
        {
            User user = dbContext.Users.Find(email);
            userOptionToUser(userOption, user);
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
