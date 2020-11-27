using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CrowdFundCore.Options;
using CrowdFundCoreServices;
using Microsoft.AspNetCore.Hosting;
using CrowdFundMVC.Models;

namespace CrowdFundMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService packageService;

        public PackageController(IPackageService packageService)
        {
            this.packageService = packageService;
        }

       
        [HttpPost]
        public PackageOption AddPackage([FromBody] PackageOption packageOpt)
        {
           
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
        [HttpGet]
        public List<PackageOption> GetAllPackages()
        {
            return packageService.GetAllPackages();
        }

    }
}
