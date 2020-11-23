using CrowdFundCore.Options;
using Microsoft.AspNetCore.Http;
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
    
    public class PackageWithFileModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Reward { get; set; }
        public string Photo { get; set; }
        public IFormFile Picture { get; set; }
    }


}
