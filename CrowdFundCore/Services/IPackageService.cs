using System.Collections.Generic;
using CrowdFundCore.Options;

namespace CrowdFundCoreServices
{
    public interface IPackageService
    {
        PackageOption CreatePackage(PackageOption packageOption);
        PackageOption UpdatePackage(PackageOption packageOption,int id);
        bool DeletePackage(int id);
        List<PackageOption> GetAllPackages();
        PackageOption GetPackageById(int id);
    }
}
