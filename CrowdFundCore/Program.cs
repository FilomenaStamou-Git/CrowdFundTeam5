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
            //for (var i = 0; i < 10; i++)
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



            //------------------------Add Project------------------

            //using var db = new CFDBContext();

            //for (var i = 0; i < 3; i++)
            //{
            //    Project project = new Project
            //    {
            //        Title = "Test Project" + i,
            //        Amount = 25000 + (100 * i),
            //        Fundings = 12000 + (50 * i),
            //        Description = "Desc " + i,
            //        Categories = Category.Photography,
            //        Created = DateTime.Now,
            //        UserId = 1 + i,
            //    };
            //    db.Projects.Add(project);

            //}
            //db.SaveChanges();


            //using var db = new CFDBContext();

            //for (var i = 0; i < 3; i++)
            //{
            //    Project project = new Project
            //    {
            //        Title = "Test Project" + i,
            //        Amount = 25000 + (100 * i),
            //        Fundings = 12000 + (50 * i),
            //        Description = "Desc " + i,
            //        Categories = Category.Music,
            //        Created = DateTime.Now,
            //        UserId = 1 + i,
            //    };
            //    db.Projects.Add(project);

            //}
            //db.SaveChanges();





            /////* Add Package */

            //for (var i = 0; i < 3; i++)
            //{
            //    using var db = new CFDBContext();

            //    var package = new Package
            //    {
            //        Description = "Gold Package ",
            //        Reward = 300,
            //        ProjectId = 1 + i
            //    };

            //    db.Packages.Add(package);
            //    db.SaveChanges();
            //}

            //for (var i = 0; i < 3; i++)
            //{
            //    using var db = new CFDBContext();

            //    var package = new Package
            //    {
            //        Description = "Platinum Package ",
            //        Reward = 600,
            //        ProjectId = 1 + i
            //    };

            //    db.Packages.Add(package);
            //    db.SaveChanges();
            //}

            //for (var i = 0; i < 3; i++)
            //{
            //    using var db = new CFDBContext();

            //    var package = new Package
            //    {
            //        Description = "Diamong Package ",
            //        Reward = 800,
            //        ProjectId = 1 + i
            //    };

            //    db.Packages.Add(package);
            //    db.SaveChanges();
            //}


        }
    }
}
