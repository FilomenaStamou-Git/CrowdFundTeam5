using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrowdFundCore.Options;
using CrowdFundCore.Services;
using CrowdFundCoreServices;

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

        [HttpGet]
        public List<PackageOption> GetAllPackages()
        {
            return packageService.GetAllPackages();
        }

        [HttpPost]
        public PackageOption AddPackage(PackageOption packageOpt)
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
    }
}
