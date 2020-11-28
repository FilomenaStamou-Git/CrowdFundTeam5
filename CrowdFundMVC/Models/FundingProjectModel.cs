using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundMVC.Models
{
    public class FundingProjectModel
    {
        public int Id { get; set; }
        public int Projectid { get; set; }
        public int Packageid { get; set; }
        public int Userid { get; set; }
        public decimal Reward { get; set; }
    }
}
