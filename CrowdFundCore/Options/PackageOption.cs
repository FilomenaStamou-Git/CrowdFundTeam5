using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundCore.Options
{
    public class PackageOption
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Reward { get; set; }
        public string Photo { get; set; }
        public int ProjectId { get; set; }
        public bool IsActive { get; set; }
    }
}
