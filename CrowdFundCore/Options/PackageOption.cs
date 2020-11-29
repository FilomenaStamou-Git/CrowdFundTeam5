using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundCore.Options
{
    public class PackageOption
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Reward { get; set; }
        public int ProjectId { get; set; }
        public int Count { get; set; }
    }
}
