using System;
using System.Collections.Generic;
using System.Text;
using CrowdFundCore.Models;
using CrowdFundCore.Options;

namespace CrowdFundCoreServices
{
    public interface IPackageService
    {
        PackageOption CreatePackage(PackageOption packageOption);
        PackageOption UpdatePackage(PackageOption packageOption,int id);
        bool DeletePackage(int id);
        PackageOption UpdateActivity(PackageOption isActive, int id); 
    }
}
