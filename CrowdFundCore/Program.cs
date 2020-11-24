using System;
using CrowdFundCore.Models;
using CrowdFundCore.Options;
using CrowdFundCore.Services;
using CrowdFundCore.Data;

namespace CrowdFundCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the test area of the CrowdFunding website!");

            //var userOpt = new UserOption()
            //{
            //    FirstName = "Firstname",
            //    LastName = "Lastname",
            //    Email = "test@gmail.com",
            //    Password = "test",
            //    Dob = DateTime.Today


            //};

            using var db = new CFDBContext();
            Package package = new Package()
            {
                Amount = 50,
                Description = "This is a description",
                Reward = "Reward here"
            };
            db.Packages.Add(package);
            db.SaveChanges();
        }
    }
}
