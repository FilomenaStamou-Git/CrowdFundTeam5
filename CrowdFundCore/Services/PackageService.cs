using System;
using System.Collections.Generic;
using System.Text;
using CrowdFundCore.Options;
using CrowdFundCoreServices;
using CrowdFundCore.Data;
using CrowdFundCore.Models;
using System.Linq;

namespace CrowdFundCore.Services
{
    public class PackageService : IPackageService
    {
        private readonly CFDBContext dbContext;
        public PackageService(CFDBContext dbContext)
        {
           this.dbContext = dbContext;
        }


        public List<PackageOption> GetAllPackages()
        {
            List<Package> packages = dbContext.Packages.ToList();
            List<PackageOption> packagesOpt = new List<PackageOption>();
            packages.ForEach(package => packagesOpt.Add(new PackageOption
            {
                Amount = package.Amount,
                Description = package.Description,
                Reward = package.Reward,
                IsActive = package.IsActive,
                Id = package.Id
            }));

            return packagesOpt;
        }


        public PackageOption CreatePackage(PackageOption packageOption)
        {
            Package package = new Package
            {
                Amount = packageOption.Amount,
                Description = packageOption.Description,
                Reward = packageOption.Reward,
                IsActive = false //by default is TRUE
            };

            dbContext.Packages.Add(package);
            dbContext.SaveChanges();
            return new PackageOption
            {
                Amount = package.Amount,
                Description = package.Description,
                Reward = package.Reward,
                IsActive = package.IsActive
            };
        }

        public bool DeletePackage(int id)
        {
            Package package = dbContext.Packages.Find(id);
            if (package == null) return false;
            dbContext.Packages.Remove(package);
            dbContext.SaveChanges();
            return true;
        }

        public PackageOption UpdatePackage(PackageOption packageOpt, int id)
        {
            Package package = dbContext.Packages.Find(id);
            packageOptToPackage(packageOpt, package);
            dbContext.SaveChanges();

            return new PackageOption
            {
                Amount = package.Amount,
                Description = package.Description,
                Reward = package.Reward,
                IsActive = package.IsActive
            };
        }

        public PackageOption GetPackageById(int id)
        {
            Package package = dbContext.Packages.Find(id);
            return new PackageOption
            {
                Amount = package.Amount,
                Description = package.Description,
                Reward = package.Reward,
                IsActive = package.IsActive,
                Id = package.Id
            };
        }

        private static void packageOptToPackage(PackageOption packageOpt, Package package)
        {
            package.Amount = packageOpt.Amount;
            package.Description = packageOpt.Description;
            package.Reward = packageOpt.Reward;
            package.IsActive = packageOpt.IsActive;
        }
    }
}
