﻿using System;
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



            //------------------------Add Project------------------


            for (var i = 0; 10 < 1; i++)
            {
                using var db = new CFDBContext();
                Project project = new Project
                {
                    Title = "Test Project" + i,
                    Amount = 25000 + (50 * i),
                    Fundings = 12000 + (10 * i),
                    Description = "Desc 10" + i,
                    Categories = Category.Technology,
                    Created = DateTime.Now,
                    UserId = 3 + i,
                };
                db.Projects.Add(project);
                db.SaveChanges();

            }

           // Photo ="https://media0.giphy.com/media/xULW8zqkikkOBKH0LS/giphy.gif?cid=ecf05e47y7ywwgkj3i6zqpjxu1f9h48fgafy5e3fx88ozi7l&rid=giphy.gif"



            /////* Add Package */

            //for (var i = 0; i < 5; i++)
            //{
            //    using var db = new CFDBContext();

            //    var package = new Package
            //    {
            //        Description = "Silver Package ",
            //        Reward = 250,
            //        ProjectId = 3 + i
            //    };

            //    db.Packages.Add(package);
            //    db.SaveChanges();
            //}


        }
    }
}
