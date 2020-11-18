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
                    Email = userOption.Email
                };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return new UserOption
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
            }

        public UserOption DeleteUser(UserOption userOption, string email)
        {
            throw new NotImplementedException();
        }

        public UserOption UpdateUser(UserOption userOption, string email)
        {
            throw new NotImplementedException();
        }        
    }
}
