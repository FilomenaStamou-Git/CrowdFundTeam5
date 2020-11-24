using System;
using System.Collections.Generic;
using System.Text;
using CrowdFundCore.Models;

namespace CrowdFundCore.Models
{
    public class Package
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Reward { get; set; }
        public string Photo { get; set; }
        public Project Project { get; set; }
    }
}