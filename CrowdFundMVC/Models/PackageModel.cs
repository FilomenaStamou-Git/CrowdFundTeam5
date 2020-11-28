using CrowdFundCore.Options;
using System.Collections.Generic;

namespace CrowdFundMVC.Models
{
    public class PackageModel
    {
        public List<PackageOption> Packages { get; set; }
    }


    public class PackageOptionModel
    {
        public PackageOption package { get; set; }
    }
}
