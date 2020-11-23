using System.Collections.Generic;
using CrowdFundCore.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

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

    public class ProjectWithFileModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Update { get; set; }
        public string Photo { get; set; }
        public string Video { get; set; }
        public decimal Amount { get; set; }
        public IFormFile Picture { get; set; }       
    }

}
