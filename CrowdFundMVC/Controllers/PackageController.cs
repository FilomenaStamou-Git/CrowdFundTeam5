using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrowdFundCore.Options;
using CrowdFundCore.Services;
using CrowdFundCoreServices;
using Microsoft.AspNetCore.Hosting;
using CrowdFundMVC.Models;
using System.IO;

namespace CrowdFundMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService packageService;
        private readonly IWebHostEnvironment hostingEnvironment;

        public PackageController(IPackageService packageService, IWebHostEnvironment environment)
        {
            this.packageService = packageService;
            hostingEnvironment = environment;
        }

        [HttpGet]
        public List<PackageOption> GetAllPackages()
        {
            return packageService.GetAllPackages();
        }

        [HttpPost]
        public PackageOption AddPackage([FromForm] PackageWithFileModel packageOptWithFileModel)
        {

            if (packageOptWithFileModel == null) return null;
            var formFile = packageOptWithFileModel.Picture;

            var filename = packageOptWithFileModel.Picture.FileName;

            if (formFile.Length > 0)
            {

                var filePath = Path.Combine(hostingEnvironment.WebRootPath, "uploadedimages", filename);
                using (var stream = System.IO.File.Create(filePath))
                {
                    formFile.CopyTo(stream);
                }
            }

            PackageOption packageOpt = new PackageOption
            {
                Amount = packageOptWithFileModel.Amount,
                Description = packageOptWithFileModel.Description,
                Reward = packageOptWithFileModel.Reward,
                Photo = packageOptWithFileModel.Photo
            };

            packageOpt.Photo = filename;

            PackageOption packageOption = packageService.CreatePackage(packageOpt);
            return packageOption;
        }

        [HttpPut("{id}")]
        public PackageOption UpdatePackage(PackageOption packageOpt, int id)
        {
            return packageService.UpdatePackage(packageOpt, id);

        }
        [HttpDelete("{id}")]
        public bool DeletePackage(int id)
        {
            return packageService.DeletePackage(id);
        }
    }
}
