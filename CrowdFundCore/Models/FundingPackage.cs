using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundCore.Models
{
    public class FundingPackage
    {
        public int PackageId { get; set; }
        public int FundingProjectId { get; set; }

        public FundingProject FundingProject { get; set; }
        public Package Package { get; set; }

    }
}
