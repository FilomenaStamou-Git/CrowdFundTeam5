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
            using var db = new CFDBContext();
            Package package = new Package()
            {
                Amount = 50,
                Description = "This is a description",
                Reward = "Reward here",
                IsActive = true
            };
            db.Packages.Add(package);
            db.SaveChanges();
        }
    }
}
