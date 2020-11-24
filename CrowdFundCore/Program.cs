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

            //--------------CREATE USER--------------------------


            //var userOpt = new UserOption()
            //{
            //    FirstName = "Firstname",
            //    LastName = "Lastname",
            //    Email = "test@gmail.com",
            //    Password = "test",
            //    Dob = DateTime.Today


            //};

            //using var db = new CFDBContext();
            //    User user = new User
            //{
            //    FirstName = "Danai",
            //    LastName = "Macs",
            //    Email = "Jdan@gmail.com",               
            //};

            //db.Users.Add(user);           
            //db.SaveChanges(); 

            // User user1 = db.Users.Find(1);
            // Console.WriteLine(user1.FirstName);

            //------------------------Add Project------------------



            //using var db = new CFDBContext();
            //Project project = new Project
            //{
            //    Title = "Drone Delivery",
            //    Amount = 12000,
            //    Fundings = 4300,
            //    Description = "Desc 10",
            //    Category = "Technology",
            //    Created = DateTime.Now

            //};

            //db.Projects.Add(project);
            //db.SaveChanges();


        }
    }
}
