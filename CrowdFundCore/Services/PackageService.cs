using System.Collections.Generic;
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

        public PackageOption CreatePackage(PackageOption packageOption)
        {
            if (string.IsNullOrWhiteSpace(packageOption.Description) ||
                packageOption.Reward.Equals(null))  return null;

            Package package = new Package
            {
                Id =packageOption.Id,
                Description = packageOption.Description,
                Reward = packageOption.Reward,
                ProjectId = packageOption.ProjectId              
            };

            dbContext.Packages.Add(package);
            dbContext.SaveChanges();

            return new PackageOption
            {
                Id = package.Id,
                Description = package.Description,
                Reward = package.Reward,
                ProjectId = package.ProjectId
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
                Description = package.Description,
                Reward = package.Reward              
            };
        }

        public PackageOption GetPackageById(int id)
        {
            Package package = dbContext.Packages.Find(id);
                return new PackageOption
            {
                Id = package.Id,             
                Description = package.Description,
                Reward = package.Reward,
                ProjectId = package.ProjectId,
            };
        }

        private static void packageOptToPackage(PackageOption packageOpt, Package package)
        {
            package.Description = packageOpt.Description;
            package.Reward = packageOpt.Reward;


        }

        public List<PackageOption> GetAllPackages()
        {
            List<Package> packages = dbContext.Packages.ToList();
            List<PackageOption> packagesOpt = new List<PackageOption>();
            packages.ForEach(package => packagesOpt.Add(new PackageOption
            {
                Id = package.Id,
                Description = package.Description,
                Reward = package.Reward,
                ProjectId =package.ProjectId
            }));

            return packagesOpt;
        }




    }
}
