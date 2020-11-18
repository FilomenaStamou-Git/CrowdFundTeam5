using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCF.Options
{
    public class ProjectOption
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }  //LIST? Enumeration??
        public string Update { get; set; }
        public DateTime Created { get; set; }
        public decimal Ammount { get; set; }
    }
}
