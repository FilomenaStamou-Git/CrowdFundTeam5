using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundCore.Options
{
    public class ProjectOption
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }  //LIST? Enumeration??
        public string Photo { get; set; }
        public string Video { get; set; }
        public string Update { get; set; }
        public DateTime Created { get; set; }
        public decimal Amount { get; set; }
        
    }
}
