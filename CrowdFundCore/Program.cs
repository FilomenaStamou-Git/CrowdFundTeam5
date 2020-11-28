using System;
using CrowdFundCore.Models;
using CrowdFundCore.Options;
using CrowdFundCore.Services;
using CrowdFundCore.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CrowdFundCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the test area of the CrowdFunding website!");

            ////--------------CREATE USER--------------------------
            //using var db = new CFDBContext();
            //for (var i = 0; i < 40; i++)
            //{
                
            //    User user = new User
            //    {
            //        FirstName = "Test FirstName " + i,
            //        LastName = "Test LastName " + i,
            //        Email = "test@mail.com",
            //        Password = "test"

            //    };

            //    db.Users.Add(user);
            //    db.SaveChanges();
            //}

            //User user1 = db.Users.Find(1);
            //Console.WriteLine(user1.FirstName);

            ////------------------------Add Project------------------


            //for (var i = 0; i < 25; i++)
            //{
                
            //    Project project = new Project
            //    {
            //        Title = "Test Project" + i,
            //        Amount = 25000 + (50 * i),
            //        Fundings = 12000 + (10 * i),
            //        Description = "Desc 10" + i,
            //        Categories = Category.Technology,
            //        Created = DateTime.Now,
            //        UserId = 3 + i
            //    };
            //    db.Projects.Add(project);
            //    db.SaveChanges();

            //}




            /////* Add Package */

            ////for (var i = 0; i < 5; i++)
            ////{
            ////    using var db = new CFDBContext();

            ////    var package = new Package
            ////    {
            ////        Description = "Silver Package ",
            ////        Reward = 250,
            ////        ProjectId = 3 + i
            ////    };

            ////    db.Packages.Add(package);
            ////    db.SaveChanges();
            ////}


        }
    }
}
