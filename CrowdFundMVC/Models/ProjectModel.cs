using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundCore.Options;

namespace CrowdFundMVC.Models
{
    public class ProjectModel
    {
        public List<ProjectOption> Projects { get; set; }
    }

    public class ProjectOptionModel
    {
        public ProjectOption project { get; set; }
    }
}
