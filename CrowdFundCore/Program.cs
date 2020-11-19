﻿using System;
using CrowdFundCore.Models;
using CrowdFundCore.Options;
using CrowdFundCore.Services;
using ProjectCF_Console.Data;

namespace ProjectCF_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the test area of the CrowdFunding website!");
            Console.WriteLine("I brought giannis branch to main");

            //var userOpt = new UserOption()
            //{
            //    FirstName = "Firstname",
            //    LastName = "Lastname",
            //    Email = "test@gmail.com",
            //    Password = "test",
            //    Dob = DateTime.Today


            //};

            using var db = new CFDBContext();
                User user = new User
            {
                FirstName = "John",
                LastName = "Macs",
                Email = "John@gmail.com",               
            };
                   
            db.Users.Add(user);           
            db.SaveChanges(); 

           // User user1 = db.Users.Find(1);
           // Console.WriteLine(user1.FirstName);

        }
    }
}