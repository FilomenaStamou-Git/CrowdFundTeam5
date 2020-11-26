using System.Collections.Generic;
using CrowdFundCore.Models;
using CrowdFundCore.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrowdFundMVC.Models
{
    public class ProjectModel
    {
        public List<ProjectwithFileModel> Projects { get; set; }
    }

    public class ProjectOptionModel
    {
        public ProjectwithFileModel project { get; set; }
    }

    public class ProjectWithFileModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Categories { get; set; }
        public string Update { get; set; }
        public string Photo { get; set; }
        public string Video { get; set; }
        public decimal Amount { get; set; }
        public decimal Fundings { get; set; }
        public IFormFile Picture { get; set; }       
    }

}
