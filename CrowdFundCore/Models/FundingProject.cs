using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundCore.Models
{
    public class FundingProject
    {
        public int Id { get; set; }
        public int projectid { get; set; }
        public int packageid { get; set; }
        public int userid { get; set; }
        public decimal reward { get; set; } 
    }
}
