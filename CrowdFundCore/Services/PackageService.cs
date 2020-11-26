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
                Description = package.Description,
                Reward = package.Reward,
                Photo = package.Photo,
                Id = package.Id
            }));

            return packagesOpt;
        }


        public PackageOption CreatePackage(PackageOption packageOption)
        {

            //var project = dbContext
            //   .Set<Project>()
            //   .Where(p => p.Id == packageOption.ProjectId)  //Include(p=>p.Package)
            //   .SingleOrDefault();


            Package package = new Package
            {
                Description = packageOption.Description,
                Reward = packageOption.Reward,
                Photo = packageOption.Photo,
                IsActive = true,
                
            };


            //project.Packages.Add(package);
            //dbContext.Update(project);
            dbContext.Packages.Add(package);
            dbContext.SaveChanges();
            return new PackageOption
            {
                Description = package.Description,
                Reward = package.Reward,
                Photo = packageOption.Photo
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
            //var project = dbContext
            //    .Set<Project>()
            //    .Where(p => p.Id == packageOpt.ProjectId)               // .Include(p => p.Package)
            //    .SingleOrDefault();
            //project.Packages.Add(package);
            //dbContext.Update(project);

            Package package = dbContext.Packages.Find(id);         
            packageOptToPackage(packageOpt, package);
            dbContext.SaveChanges();

            return new PackageOption
            {
                Description = package.Description,
                Reward = package.Reward,
                Photo = package.Photo
            };
        }

        public PackageOption GetPackageById(int id)
        {
            Package package = dbContext.Packages.Find(id);
            return new PackageOption
            {
                Description = package.Description,
                Reward = package.Reward,
                Photo = package.Photo,
                Id = package.Id
            };
        }

        private static void packageOptToPackage(PackageOption packageOpt, Package package)
        {
            package.Description = packageOpt.Description;
            package.Reward = packageOpt.Reward;
            package.Photo = packageOpt.Photo;
        }
    }
}
