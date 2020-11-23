﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundCore.Models;

namespace CrowdFundCore.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }  //LIST? Enumeration??
        public string Update { get; set; }
        public DateTime Created { get; set; }
        public decimal Amount { get; set; }
        public string Photo { get; set; }
        public string Video { get; set; }
        public decimal Fundings { get; set; }
        public User User { get; set; }
        public List<Package> Packages { get; set; } 
    }
}
