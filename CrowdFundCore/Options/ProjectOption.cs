using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundCore.Models;
using Microsoft.AspNetCore.Http;

namespace CrowdFundCore.Options
{
    public class ProjectwithFileModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Categories { get; set; }
        public string Photo { get; set; }
        public string Video { get; set; }
        public string Update { get; set; }
        public DateTime Created { get; set; }
        public decimal Amount { get; set; }
        public decimal Fundings { get; set; }
        public List<Package> FundingPackages { get; set; }
        public int UserId { get; set; }
        public IFormFile Picture { get; set; }

    }
}
