using System;
using System.Collections.Generic;
using System.Text;
using ProjectCF_Console.Models;
using ProjectCF_Console.Options;

namespace ProjectCF_Console.Services
{
    public interface IPackageService
    {
        PackageOption CreatePackage(PackageOption packageOption);
        PackageOption UpdatePackage(PackageOption packageOption,int id);
        bool DeletePackage(int id);
        PackageOption UpdateActivity(PackageOption isActive, int id); 
    }
}
