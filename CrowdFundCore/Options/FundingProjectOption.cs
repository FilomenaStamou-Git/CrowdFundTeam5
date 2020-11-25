using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundCore.Options
{
    public class FundingProjectOption
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int PackageId { get; set; }
        public decimal Ammount { get; set; }
    }
}


